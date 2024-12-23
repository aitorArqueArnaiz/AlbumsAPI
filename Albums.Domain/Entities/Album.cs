using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albums.Domain.Entities
{
    public class Album
    {
        /*
        "userId": 1,
        "id": 1,
        "title": "quidem molestiae enim"
         */

        public int UserId { get; set; }
        public int Id { get; set; }
        public required string Title { get; set; }
    }
}
