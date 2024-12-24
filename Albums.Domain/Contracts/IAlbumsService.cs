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
        Task SaveAlbumsAndPhotosAsync();
        Task<IEnumerable<Album>> GetAlbumsFilteredByTitleAsync(string title);
    }
}
