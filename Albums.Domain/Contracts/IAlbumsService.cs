using Albums.Domain.Entities;

namespace Albums.Domain.Contracts
{
    public interface IAlbumsService
    {
        /// <summary>
        /// method that deletes an existing album by its id.
        /// </summary>
        /// <param name="id">album unique identifier.</param>
        /// <returns></returns>
        Task DeleteAlbumAsync(int id);
        /// <summary>
        /// Method that gets an album by its id.
        /// </summary>
        /// <param name="id">album unique identifier.</param>
        /// <returns></returns>
        Album GetAlbumByIdAsync(int id);
        /// <summary>
        /// Method that checks that Album already exist for a given user.
        /// </summary>
        /// <param name="id">the album id.</param>
        /// <param name="userId">the user id.</param>
        /// <returns></returns>
        Task<bool> ValidateAlbumUserExistsAsync(int id, int userId);
        /// <summary>
        /// Method that creates new album.
        /// </summary>
        /// <param name="id">albun unique identifier.</param>
        /// <param name="userId">album user id.</param>
        /// <param name="title">album title.</param>
        /// <returns></returns>
        Task CreateAlbumAsync(int id, int userId, string title);
        /// <summary>
        /// Method that updates an existing album by its id.
        /// </summary>
        /// <param name="id">album identifier.</param>
        /// <param name="userId">album user id.</param>
        /// <param name="newTitle">album new title.</param>
        /// <returns></returns>
        Task UpdateAlbumAsync(int id, int userId, string newTitle);
        /// <summary>
        /// Method that saves all albums/photos data in the data base.
        /// </summary>
        /// <returns></returns>
        Task SaveAlbumsAndPhotosAsync();
        /// <summary>
        /// Method that gets the album filtered by its title.
        /// </summary>
        /// <param name="title">the album title.</param>
        /// <returns>albums filtered.</returns>
        Task<IEnumerable<Album>> GetAlbumsFilteredByTitleAsync(string title);
    }
}
