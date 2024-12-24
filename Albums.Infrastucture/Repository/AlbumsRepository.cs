using Albums.Domain.Entities;
using Albums.Infrastucture.interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albums.Infrastucture.Repository
{
    public class AlbumsRepository : IAlbumsRepository
    {
        private string baseUrl = "https://jsonplaceholder.typicode.com/";

    public async Task<IEnumerable<Album>> GetAlbumsAsync()
        {
            var albumsJson = await GetStringAsync(baseUrl + "albums");
            // Here I use Newtonsoft.Json to deserialize JSON string to User object
            var albums = JsonConvert.DeserializeObject<IEnumerable<Album>>(albumsJson);
            return albums;
        }

        private async Task<string> GetStringAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(url);
            }
        }
    }
}
