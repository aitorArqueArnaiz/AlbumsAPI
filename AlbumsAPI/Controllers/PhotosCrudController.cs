using Albums.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AlbumsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotosCrudController : Controller
    {
        private readonly ILogger<AlbumsController> _logger;
        private readonly IPhotosService _photosService;

        public PhotosCrudController(ILogger<AlbumsController> logger, IPhotosService photosService)
        {
            _logger = logger;
            _photosService = photosService;
        }


        [HttpGet(Name = "GetPhotoById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var photo = _photosService.GetPhotoByIdAsync(id);
                return Ok(photo);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred during get photo {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        [HttpPost(Name = "createPhoto")]
        public async Task<IActionResult> CreatePhotoAsync(int id, int albumId, string title, string url, string thumbnail_url)
        {
            try
            {
                _photosService.CreatePhotoAsync(id,albumId,title,url,thumbnail_url);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred during creating new photo {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        [HttpPatch(Name = "UpdatePhotoById")]
        public async Task<IActionResult> UpdatePhotoByIdAsync(int id, int albumId, string newTitle, string newUrl, string newThumbnailUrl)
        {
            try
            {
                await _photosService.UpdatePhotoAsync(id, albumId, newTitle, newUrl, newThumbnailUrl);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred during updating photo {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete(Name = "DeletePhotoById")]
        public async Task<IActionResult> DeletePhotoByIdAsync(int id)
        {
            try
            {
                await _photosService.DeletePhotoAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred during deleting photo {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
