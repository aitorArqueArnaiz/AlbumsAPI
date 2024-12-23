using Albums.Business.Services;
using Albums.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AlbumsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : ControllerBase
    {

        private readonly ILogger<AlbumsController> _logger;
        private readonly IAlbumsService _albumsService;

        public AlbumsController(ILogger<AlbumsController> logger, IAlbumsService albumsService)
        {
            _logger = logger;
            _albumsService = albumsService;
        }

        [HttpGet(Name = "SaveAlbumsAndPhotos")]
        public async Task<IActionResult> Save()
        {
            return Ok();
        }
    }
}
