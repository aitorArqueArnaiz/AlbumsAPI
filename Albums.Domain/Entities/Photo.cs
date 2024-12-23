using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albums.Domain.Entities
{
    public class Photo
    {
        /*
         {
            "albumId": 1,
            "id": 1,
            "title": "accusamus beatae ad facilis cum similique qui sunt",
            "url": "https://via.placeholder.com/600/92c952",
            "thumbnailUrl": "https://via.placeholder.com/150/92c952"
        }
         */

        public int AlbumId { get; set; }
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Url { get; set; }
        public required string ThumbnailUrl { get; set; }
    }
}
