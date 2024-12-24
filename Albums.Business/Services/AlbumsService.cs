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

        public async Task<IEnumerable<Album>> GetAlbumsFilteredByTitleAsync(string title)
        {
            var albums = await _albumsRepository.GetAlbumsAsync();
            var filteredAlbums = albums.Where(album => album.Title == title);
            return filteredAlbums;
        }

        public async Task SaveAlbumsAndPhotosAsync()
        {
            // Get Albums and photos information.
            var albumsResponse = await _albumsRepository.GetAlbumsAsync();
            var photosResponse  = await _photosRepository.GetPhotosAsync();

            // Save information into data base.
            string sqlAlbumsInsertQuery = @"";
            foreach (var album in albumsResponse)
            {

            }

            string sqlPhotosInsertQuery = @"";
            foreach (var photo in photosResponse)
            {

            }
        }
    }
}
