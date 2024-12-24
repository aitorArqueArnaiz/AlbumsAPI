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

        public async Task<IEnumerable<Photo>> GetPhotosFilteredAsync()
        {
            var photos = await _photosRepository.GetPhotosAsync();
            return photos;
        }
    }
}
