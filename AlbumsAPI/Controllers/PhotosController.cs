using Albums.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AlbumsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotosController : Controller
    {
        private readonly ILogger<AlbumsController> _logger;
        private readonly IPhotosService _photosService;

        public PhotosController(ILogger<AlbumsController> logger, IPhotosService photosService)
        {
            _logger = logger;
            _photosService = photosService;
        }

        [Route("get_photo_by_title")]
        [HttpGet]
        public async Task<IActionResult> GetByTitle(string title)
        {
            try
            {
                var response = await _photosService.GetPhotosFilteredByTitleAsync(title);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred during get photos {ex.Message}");
                throw new Exception(ex.Message);
            }
        }


        [Route("get_photos_by_album")]
        [HttpGet]
        public async Task<IActionResult> GetByAlbumId(int album)
        {
            try
            {
                var response = await _photosService.GetPhotosFilteredByAlbumAsync(album);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred during get photos {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
