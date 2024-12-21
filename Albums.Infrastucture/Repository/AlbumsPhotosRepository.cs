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
    public class AlbumsPhotosRepository : IAlbumsPhotosRepository
    {
        private static string baseUrl = "https://jsonplaceholder.typicode.com/";

    public async Task<Album> GetUserAsync(int userId)
        {
            var userJson = await GetStringAsync(baseUrl + "users/" + userId);
            // Here I use Newtonsoft.Json to deserialize JSON string to User object
            var user = JsonConvert.DeserializeObject<Album>(userJson);
            return user;
        }

        private static Task<string> GetStringAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return httpClient.GetStringAsync(url);
            }
        }
    }
}
