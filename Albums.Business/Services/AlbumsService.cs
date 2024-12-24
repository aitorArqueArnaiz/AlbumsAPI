using Albums.Domain.Contracts;
using Albums.Domain.Entities;
using Albums.Infrastucture.Data.Repositories;
using Albums.Infrastucture.interfaces;
using Albums.Infrastucture.Repository;

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

        public async Task<Album> CreateAlbumAsync(int id, int userId, string title)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAlbumAsync(int id)
        {
            string deleteSqlQuery = @"";
            await _albumsDbRepository.DeleteAsync(deleteSqlQuery);
        }

        public async Task<Album> GetAlbumByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Album>> GetAlbumsFilteredByTitleAsync(string title)
        {
            var albums = await _albumsRepository.GetAlbumsAsync();
            var filteredAlbums = albums.Where(album => album.Title == title);
            return filteredAlbums;
        }

        public async Task SaveAlbumsAndPhotosAsync()
        {
            var sqlAlbumsInsertQuery = @"INSERT INTO dbo.albums (id, user_id, title) VALUES ";

            // Get Albums and photos information.
            var albumsResponse = await _albumsRepository.GetAlbumsAsync();
            var photosResponse  = await _photosRepository.GetPhotosAsync();

            // Save albums and photos api response information into data base.
            foreach (var album in albumsResponse)
            {
                sqlAlbumsInsertQuery += $"({album.Id}, {album.UserId}, '{album.Title}'), ";
            }
            sqlAlbumsInsertQuery = sqlAlbumsInsertQuery.Remove(sqlAlbumsInsertQuery.Length - 2, 1) + ";";
            await _albumsDbRepository.AddAsync(sqlAlbumsInsertQuery);

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
            throw new NotImplementedException();
        }
    }
}
