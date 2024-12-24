using Albums.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albums.Domain.Contracts
{
    public interface IAlbumsService
    {
        Task DeleteAlbumAsync(int id);
        Album GetAlbumByIdAsync(int id);
        Task CreateAlbumAsync(int id, int userId, string title);
        Task UpdateAlbumAsync(int id, int userId, string newTitle);
        Task SaveAlbumsAndPhotosAsync();
        Task<IEnumerable<Album>> GetAlbumsFilteredByTitleAsync(string title);
    }
}
