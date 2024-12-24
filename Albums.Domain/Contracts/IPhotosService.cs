using Albums.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albums.Domain.Contracts
{
    public interface IPhotosService
    {
        Task<Photo> GetPhotoByIdAsync(int id);
        Task DeletePhotoAsync(int id);
        Task<Photo> CreatePhotoAsync(int id, int albumId, string title, string url, string thumbnailUrl);
        Task UpdatePhotoAsync(int id, int albumId, string newTitle, string newUrl, string newThumbnailUrl);
        Task<IEnumerable<Photo>> GetPhotosFilteredByTitleAsync(string title);
        Task<IEnumerable<Photo>> GetPhotosFilteredByAlbumAsync(int album);
    }
}
