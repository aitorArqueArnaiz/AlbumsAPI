using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albums.Domain.Entities
{
    public class AlbumsPhotos
    {
        public IEnumerable<Photo> Photos { get; set; }
    }
}
