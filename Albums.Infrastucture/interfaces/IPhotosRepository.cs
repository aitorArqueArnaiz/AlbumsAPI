using Albums.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albums.Infrastucture.interfaces
{
    public interface IPhotosRepository
    {
        Task<IEnumerable<Photo>> GetPhotosAsync();
    }
}
