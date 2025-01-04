using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumsFormulary.DataStructures
{
    public class AlbumPhoto
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
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}

