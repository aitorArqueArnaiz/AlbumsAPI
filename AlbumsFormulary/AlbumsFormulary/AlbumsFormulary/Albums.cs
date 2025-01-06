using AlbumsFormulary.DataStructures;
using Newtonsoft.Json;

namespace AlbumsFormulary
{
    public partial class Albums : Form
    {
        private string baseUrl = "https://localhost:44374/";
        public Albums()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            try
            {
                var albumTitleFilter = titleAlbumFiltertextBox.Text;
                var albumsJson = await GetStringAsync(baseUrl + $"Albums/get_album_by_title?title={albumTitleFilter}");
                var album = JsonConvert.DeserializeObject<IEnumerable<Album>>(albumsJson);

                var photos = await GetStringAsync(baseUrl + $"Photos/get_photos_by_album?album={album.LastOrDefault().Id}");
                var albumPhotos = JsonConvert.DeserializeObject<IEnumerable<AlbumPhoto>>(photos);

                if (albumPhotos != null && albumPhotos.Any())
                {
                    foreach (var currentPhoto in albumPhotos)
                    {
                        var image = DownloadImage(currentPhoto.Url);
                        PictureBox picture = new PictureBox
                        {
                            Name = "pictureBox",
                            Size = new Size(100, 50),
                            Location = new Point(14, 17),
                            SizeMode = PictureBoxSizeMode.CenterImage,
                            Image = image,
                        };
                        panelPhotosImages.Controls.Add(picture);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Albums_Load(object sender, EventArgs e)
        {
            var photosFormulary = new AlbumsCRUD();
        }

        private async Task<string> GetStringAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(url);
            }
        }

        Image DownloadImage(string fromUrl)
        {
            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                using (Stream stream = webClient.OpenRead(fromUrl))
                {
                    return Image.FromStream(stream);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var albums = new AlbumsCRUD();
                albums.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var photos = new PhotosCRUD();
            photos.ShowDialog();
        }
    }
}
