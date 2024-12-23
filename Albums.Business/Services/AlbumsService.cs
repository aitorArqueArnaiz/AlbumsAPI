using Albums.Domain.Contracts;
using Albums.Domain.Entities;
using Albums.Infrastucture.interfaces;

namespace Albums.Business.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly IAlbumsRepository _albumsRepository;
        private readonly IPhotosRepository _photosRepository;

        public AlbumsService(
            IAlbumsRepository albumsRepository,
            IPhotosRepository photosRepository)
        {
            _albumsRepository = albumsRepository;
            _photosRepository = photosRepository;
        }

        public async Task SaveAlbumsAndPhotosAsync(IEnumerable<AlbumsPhotos> albumsPhotos)
        {
            // Get Albums and photos information.
            var albums = await _albumsRepository.GetAlbumsAsync();
            var photos  = await _photosRepository.GetPhotosAsync();

            // Save information into data base.
        }
    }
}
