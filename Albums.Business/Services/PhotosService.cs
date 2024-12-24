using Albums.Domain.Contracts;
using Albums.Domain.Entities;
using Albums.Infrastucture.interfaces;

namespace Albums.Business.Services
{
    public class PhotosService : IPhotosService
    {
        private readonly IPhotosRepository _photosRepository;

        public PhotosService(IPhotosRepository photosRepository)
        {
            _photosRepository = photosRepository;
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
    }
}
