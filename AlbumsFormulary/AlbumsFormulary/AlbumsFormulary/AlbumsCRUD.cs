using AlbumsAPI.DTOs;
using AlbumsFormulary.DataStructures;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace AlbumsFormulary
{
    public partial class AlbumsCRUD : Form
    {
        public AlbumsCRUD()
        {
            InitializeComponent();
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(textBoxAlbumId.Text);
                var userId = int.Parse(textBoxAlbumUserId.Text);
                var title = textBoxAlbumTitle.Text;

                using (var httpClient = new HttpClient())
                {
                    await httpClient.PostAsJsonAsync("https://localhost:44374/AlbumsCrud/create_new_albums", new CreateAlbumRequest()
                    {
                        Id = id,
                        UserId = userId,
                        Title = title,
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error ocurred : {ex.Message}");
            }
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(UpdateAlbumIdTextBox.Text);
                var userId = int.Parse(UpdateUserIdTextBox.Text);
                var title = UpdateAlbumTitleTextBox.Text;

                using (var httpClient = new HttpClient())
                {
                    await httpClient.PatchAsJsonAsync("https://localhost:44374/AlbumsCrud/Update_album_by_id", new UpdateAlbumRequest()
                    {
                        Id = id,
                        UserId = userId,
                        Title = title,
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error ocurred : {ex.Message}");
            }

        }

        private async void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(DeleteAlbumTextBox.Text);
                using (var httpClient = new HttpClient())
                {
                    await httpClient.DeleteAsync($"https://localhost:44374/AlbumsCrud/update_album_by_id?id={id}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error ocurred : {ex.Message}");
            }
        }

        private async void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                var id = AlbumTextBox.Text;
                var albumsJson = await GetStringAsync($"https://localhost:44374/AlbumsCrud/get_album_by_id?id={id}");
                // Here I use Newtonsoft.Json to deserialize JSON string to User object
                var albums = JsonConvert.DeserializeObject<IEnumerable<Album>>(albumsJson);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error ocurred : {ex.Message}");
            }
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
