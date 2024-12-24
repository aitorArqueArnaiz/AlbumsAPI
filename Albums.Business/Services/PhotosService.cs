using Albums.Domain.Contracts;
using Albums.Domain.Entities;
using Albums.Infrastucture.Data.Repositories;
using Albums.Infrastucture.interfaces;

namespace Albums.Business.Services
{
    public class PhotosService : IPhotosService
    {
        private readonly IPhotosRepository _photosRepository;
        private readonly IPhotosDbReposiory _photosDbReposiory;

        public PhotosService(
            IPhotosRepository photosRepository,
            IPhotosDbReposiory photosDbReposiory)
        {
            _photosRepository = photosRepository;
            _photosDbReposiory = photosDbReposiory;
        }

        public async Task CreatePhotoAsync(int id, int albumId, string title, string url, string thumbnailUrl)
        {
            string createSqlQuery = @$"INSERT INTO dbo.photos (id, album_id, title, url, thumbnail_url)
                                    VALUES ({id}, {albumId}, '{title}', '{url}', '{thumbnailUrl}');";
            await _photosDbReposiory.AddAsync(createSqlQuery);
        }

        public async Task DeletePhotoAsync(int id)
        {
            string deleteSqlQuery = @$"DELETE FROM dbo.photos WHERE id={id};";
            await _photosDbReposiory.DeleteAsync(deleteSqlQuery);
        }

        public Photo GetPhotoByIdAsync(int id)
        {
            string getSqlQuery = @$"SELECT FROM dbo.photos WHERE id={id};";
            var photo = _photosDbReposiory.GetAsync(getSqlQuery);
            return ConvertStringToPhoto(photo);
        }

        public async Task<IEnumerable<Photo>> GetPhotosFilteredByAlbumAsync(int album)
        {
            var photos = await _photosRepository.GetPhotosAsync();
            var photosFiltered = photos.Where(photo => photo.AlbumId == album);
            return photosFiltered;
        }

        public async Task<IEnumerable<Photo>> GetPhotosFilteredByTitleAsync(string title)
        {
            var photos = await _photosRepository.GetPhotosAsync();
            var photosFiltered = photos.Where(photo => photo.Title == title);
            return photosFiltered;
        }

        public async Task UpdatePhotoAsync(int id, int albumId, string newTitle, string newUrl, string newThumbnailUrl)
        {
            string updateSqlQuery = @$"UPDATE dbo.photos
                            SET album_id = {albumId}, title = '{newTitle}', url = '{newUrl}', thumbnail_url = '{newThumbnailUrl}'
                            WHERE id = {id};";
            await _photosDbReposiory.AddAsync(updateSqlQuery);
        }

        private Photo ConvertStringToPhoto(string album)
        {
            return new Photo();
        }
    }
}
