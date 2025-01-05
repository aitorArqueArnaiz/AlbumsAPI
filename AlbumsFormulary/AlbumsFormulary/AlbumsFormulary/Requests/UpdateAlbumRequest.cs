namespace AlbumsFormulary.Requests
{
    public class UpdateAlbumRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
    }
}
