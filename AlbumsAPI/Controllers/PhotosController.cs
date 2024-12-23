using Albums.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AlbumsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotosController : Controller
    {
        private readonly ILogger<AlbumsController> _logger;
        private readonly IPhotosService _albumsService;

        public PhotosController(ILogger<AlbumsController> logger, IPhotosService photosService)
        {
            _logger = logger;
            _albumsService = photosService;
        }

        [HttpGet(Name = "GetPhotos")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
