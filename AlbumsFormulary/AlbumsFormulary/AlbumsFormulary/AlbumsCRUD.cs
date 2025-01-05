using AlbumsFormulary.DataStructures;
using AlbumsFormulary.Requests;
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
            var id = int.Parse(textBoxAlbumId.Text);
            var userId = int.Parse(textBoxAlbumUserId.Text);
            var title = textBoxAlbumTitle.Text;

            using (var httpClient = new HttpClient())
            {
                await httpClient.PostAsJsonAsync("https://localhost:44374/AlbumsCrude/create_new_albums", new CreateAlbumRequest()
                {
                    Id = id,
                    UserId = userId,
                    Title = title,
                });
            }
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            var id = int.Parse(UpdateAlbumTitleTextBox.Text);
            var userId = int.Parse(UpdateAlbumTitleTextBox.Text);
            var title = UpdateAlbumTitleTextBox.Text;

            using (var httpClient = new HttpClient())
            {
                await httpClient.PatchAsJsonAsync("https://localhost:44374/AlbumsCrude/Update_album_by_id", new UpdateAlbumRequest()
                {
                    Id = id,
                    UserId = userId,
                    Title = title,
                });
            }

        }

        private async void button3_Click_1(object sender, EventArgs e)
        {
            var id = int.Parse(DeleteAlbumTextBox.Text);
            using (var httpClient = new HttpClient())
            {
                await httpClient.DeleteAsync($"https://localhost:44374/AlbumsCrude/Update_album_by_id?id={id}");
            }
        }

        private async void button4_Click_1(object sender, EventArgs e)
        {
            var id = AlbumTextBox.Text;
            var albumsJson = await GetStringAsync($"https://localhost:44374/get_album_by_id?id={id}");
            // Here I use Newtonsoft.Json to deserialize JSON string to User object
            var albums = JsonConvert.DeserializeObject<IEnumerable<Album>>(albumsJson);
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
