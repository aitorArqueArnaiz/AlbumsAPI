namespace AlbumsFormulary.Requests
{
    public class CreateAlbumRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
    }
}
