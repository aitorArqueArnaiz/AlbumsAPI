using Albums.Domain.Contracts;
using Albums.Domain.Entities;
using Albums.Infrastucture.interfaces;

namespace Albums.Business.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly IAlbumsRepository _albumsRepository;
        private readonly IPhotosRepository _photosRepository;
        private readonly IAlbumsDbRepository _albumsDbRepository;

        public AlbumsService(
            IAlbumsRepository albumsRepository,
            IPhotosRepository photosRepository,
            IAlbumsDbRepository albumsDbRepository)
        {
            _albumsRepository = albumsRepository;
            _photosRepository = photosRepository;
            _albumsDbRepository = albumsDbRepository;
        }

        public async Task CreateAlbumAsync(int id, int userId, string title)
        {
            string createSqlQuery = @$"INSERT INTO dbo.albums (id, user_id, title)
                                    VALUES ({id}, {userId}, '{title}');";
            await _albumsDbRepository.AddAsync(createSqlQuery);
        }

        public async Task DeleteAlbumAsync(int id)
        {
            string deleteSqlQuery = @$"DELETE FROM dbo.albums WHERE id={id};";
            await _albumsDbRepository.DeleteAsync(deleteSqlQuery);
        }

        public Album GetAlbumByIdAsync(int id)
        {
            string getSqlQuery = @$"SELECT * FROM dbo.albums WHERE album_id={id};";
            var album = _albumsDbRepository.GetAsync(getSqlQuery);
            return ConvertStringToAlbum(album);
        }

        public async Task<IEnumerable<Album>> GetAlbumsFilteredByTitleAsync(string title)
        {
            var albums = await _albumsRepository.GetAlbumsAsync();
            if (!string.IsNullOrEmpty(title))
            {
                var filteredAlbums = albums.Where(album => album.Title == title);
                return filteredAlbums;
            }
            return albums;
        }

        public async Task SaveAlbumsAndPhotosAsync()
        {
            var sqlAlbumsInsertQuery = @"INSERT INTO dbo.albums (id, user_id, title) VALUES ";

            // Get Albums and photos information.
            var albumsResponse = await _albumsRepository.GetAlbumsAsync();
            var photosResponse  = await _photosRepository.GetPhotosAsync();

            // Save albums.
            foreach (var album in albumsResponse)
            {
                sqlAlbumsInsertQuery += $"({album.Id}, {album.UserId}, '{album.Title}'), ";
            }
            sqlAlbumsInsertQuery = sqlAlbumsInsertQuery.Remove(sqlAlbumsInsertQuery.Length - 2, 1) + ";";
            await _albumsDbRepository.AddAsync(sqlAlbumsInsertQuery);

            // Save photos.
            for (int counter = 0; counter < photosResponse.Count(); counter = counter + 1000)
            {
                var sqlPhotosInsertQuery = @"INSERT INTO dbo.photos (id, album_id, title, url, thumbnail_url) VALUES ";
                foreach (var photo in photosResponse.Skip(counter).Take(1000))
                {
                    sqlPhotosInsertQuery += $"({photo.Id}, {photo.AlbumId}, '{photo.Title}', '{photo.Url}', '{photo.ThumbnailUrl}'), ";
                }
                sqlPhotosInsertQuery = sqlPhotosInsertQuery.Remove(sqlPhotosInsertQuery.Length - 2, 1) + ";";
                await _albumsDbRepository.AddAsync(sqlPhotosInsertQuery);
            }
            
        }

        public async Task UpdateAlbumAsync(int id, int userId, string newTitle)
        {
            string updateSqlQuery = @$"UPDATE dbo.albums
                            SET user_id = {userId}, title = '{newTitle}'
                            WHERE id = {id};";
            await _albumsDbRepository.AddAsync(updateSqlQuery);
        }

        public async Task<bool> ValidateAlbumUserExistsAsync(int id, int userId)
        {
            var result = this.GetAlbumByIdAsync(id);
            if(result.UserId == userId)
                return true;
            return false;
        }

        private Album ConvertStringToAlbum(string album)
        {
            var splitedAlbumCsv = album.Split(',');
            return new Album() {
                Id = Int32.Parse(splitedAlbumCsv[0]),
                UserId = Int32.Parse(splitedAlbumCsv[1]),
                Title = splitedAlbumCsv[2]
            };
        }
    }
}
