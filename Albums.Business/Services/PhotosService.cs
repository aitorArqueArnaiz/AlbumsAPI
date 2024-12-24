using Albums.Domain.Contracts;
using Albums.Domain.Entities;
using Albums.Infrastucture.interfaces;

namespace Albums.Business.Services
{
    public class PhotosService : IPhotosService
    {
        private readonly IPhotosRepository _photosRepository;
        private readonly IPhotosDbReposiory _photosDbReposiory;

        public PhotosService(IPhotosRepository photosRepository)
        {
            _photosRepository = photosRepository;
        }

        public async Task<Photo> CreatePhotoAsync(int id, int albumId, string title, string url, string thumbnailUrl)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePhotoAsync(int id)
        {
            string deleteSqlQuery = @"";
            await _photosDbReposiory.DeleteAsync(deleteSqlQuery);
        }

        public async Task<Photo> GetPhotoByIdAsync(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
