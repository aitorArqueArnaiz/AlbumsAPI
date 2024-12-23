using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albums.Domain.Entities
{
    public class AlbumsPhotos
    {
        public IEnumerable<Album> Albums { get; set; }
    }
}
