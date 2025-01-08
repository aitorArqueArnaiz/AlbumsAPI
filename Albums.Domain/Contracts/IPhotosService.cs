using Albums.Domain.Entities;

namespace Albums.Domain.Contracts
{
    public interface IPhotosService
    {
        /// <summary>
        /// Method that gets the photo by its id.
        /// </summary>
        /// <param name="id">the photo id.</param>
        /// <returns>the photo.</returns>
        Photo GetPhotoByIdAsync(int id);
        /// <summary>
        /// Method that deletes and existing photo by its id.
        /// </summary>
        /// <param name="id">photo id.</param>
        /// <returns></returns>
        Task DeletePhotoAsync(int id);
        /// <summary>
        /// Method that creates a new photo.
        /// </summary>
        /// <param name="id">photo unique identifier.</param>
        /// <param name="albumId">photo album id.</param>
        /// <param name="title">photo title.</param>
        /// <param name="url">photo url.</param>
        /// <param name="thumbnailUrl">photo thumbnail url</param>
        /// <returns></returns>
        Task CreatePhotoAsync(int id, int albumId, string title, string url, string thumbnailUrl);
        /// <summary>
        /// Mrthod that chcks that photo already assigned to album.
        /// </summary>
        /// <param name="id">the photo id.</param>
        /// <param name="albumId">the album id.</param>
        /// <returns></returns>
        Task<bool> ValidatePhotoExistInAlbum(int id, int albumId);
        Task<bool> ValidatePhotoExist(int id);
        /// <summary>
        /// Method that updates an existing photo.
        /// </summary>
        /// <param name="id">photo unique identifier.</param>
        /// <param name="albumId">photo album id.</param>
        /// <param name="newTitle">photo new title.</param>
        /// <param name="newUrl">photo new url.</param>
        /// <param name="newThumbnailUrl">photo new thumbnail url.</param>
        /// <returns></returns>
        Task UpdatePhotoAsync(int id, int albumId, string newTitle, string newUrl, string newThumbnailUrl);
        /// <summary>
        /// Method that gets photo by its title.
        /// </summary>
        /// <param name="title">the photo title.</param>
        /// <returns></returns>
        Task<IEnumerable<Photo>> GetPhotosFilteredByTitleAsync(string title);
        /// <summary>
        /// Method that gets the photo by its album identifier.
        /// </summary>
        /// <param name="album">album identifier.</param>
        /// <returns>photo.</returns>
        Task<IEnumerable<Photo>> GetPhotosFilteredByAlbumAsync(int? album);
    }
}
