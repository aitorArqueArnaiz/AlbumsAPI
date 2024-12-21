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
    public class PhotosRepository : IPhotosRepository
    {
        private static string baseUrl = "https://jsonplaceholder.typicode.com/";

        public async Task<IEnumerable<Photo>> GetPhotosAsync()
        {
            var photosJson = await GetStringAsync(baseUrl + "photos/");
            // Here I use Newtonsoft.Json to deserialize JSON string to User object
            var photos = JsonConvert.DeserializeObject<IEnumerable<Photo>>(photosJson);
            return photos;
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
