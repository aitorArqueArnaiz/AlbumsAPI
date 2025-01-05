using AlbumsFormulary.DataStructures;
using AlbumsFormulary.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbumsFormulary
{
    public partial class PhotosCRUD : Form
    {
        public PhotosCRUD()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(createIdTextBox.Text);
                var albumId = CreateAlbumIdTextBox.Text;
                var title = CreatePhotoTitleTextBox.Text;
                var url = CreatePhotoUrlTextBox.Text;
                var thumbnailUrl = CreatePhotoTUrlTextBox.Text;

                using (var httpClient = new HttpClient())
                {
                    await httpClient.PostAsJsonAsync("https://localhost:44374/AlbumsCrude/create_new_photo", new CreatePhotoRequest()
                    {
                        Id = id,
                        AlbumId = int.Parse(albumId),
                        Title = title,
                        Url = url,
                        ThumbnailUrl = thumbnailUrl,
                    }); ;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"error ocurred : {ex.Message} ");
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(UpdatePhotoIdTextBox.Text);
                var albumId = UpatePhotoAlbumIdTextBox.Text;
                var title = UpdatePhotoTitleTextBox.Text;
                var url = UpdatePhotoUrlTextBox.Text;
                var thumbnailUrl = UpdatePhotoTUrlTextBox.Text;

                using (var httpClient = new HttpClient())
                {
                    await httpClient.PatchAsJsonAsync("https://localhost:44374/AlbumsCrude/update_by_id", new UpdatePhotoRequest()
                    {
                        Id = id,
                        AlbumId = int.Parse(albumId),
                        Title = title,
                        Url = url,
                        ThumbnailUrl = thumbnailUrl,
                    }); ;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"error ocurred : {ex.Message} ");
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(DeletePhotoIdTextBox.Text);
                using (var httpClient = new HttpClient())
                {
                    await httpClient.DeleteAsync($"https://localhost:44374/AlbumsCrude/delete_by_id?id={id}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"error ocurred : {ex.Message} ");
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var id = GetPhotoIdTextBox.Text;
                var albumsJson = await GetStringAsync($"https://localhost:44374/get_by_id?id={id}");
                var photos = JsonConvert.DeserializeObject<IEnumerable<Album>>(albumsJson);
            }
            catch (Exception ex)
            {
                throw new Exception($"error ocurred : {ex.Message} ");
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
