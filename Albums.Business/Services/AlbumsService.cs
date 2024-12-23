using Albums.Domain.Contracts;
using Albums.Domain.Entities;
using Albums.Infrastucture.interfaces;

namespace Albums.Business.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly IAlbumsRepository _albumsRepository;

        public AlbumsService(IAlbumsRepository albumsRepository)
        {
            _albumsRepository = albumsRepository;
        }

        public async Task SaveAlbumsAndPhotosAsync(IEnumerable<AlbumsPhotos> albumsPhotos)
        {
            var albums = await _albumsRepository.GetAlbumsAsync();
        }
    }
}
