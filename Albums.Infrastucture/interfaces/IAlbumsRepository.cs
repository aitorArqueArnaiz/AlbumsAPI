using Albums.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albums.Infrastucture.interfaces
{
    public interface IAlbumsRepository
    {
        Task<IEnumerable<Album>> GetAlbumsAsync();
    }
}
