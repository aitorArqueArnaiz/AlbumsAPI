using Albums.Domain.Contracts;
using AlbumsAPI.DTOs;
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


        [Route("get_by_id")]
        [HttpGet]
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

        [Route("create_new_photo")]
        [HttpPost]
        public async Task<IActionResult> CreatePhotoAsync(CreatePhotoRequest request)
        {
            try
            {
                await _photosService.CreatePhotoAsync(request.Id, request.AlbumId, request.Title, request.Url, request.ThumbnailUrl);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred during creating new photo {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        [Route("update_by_id")]
        [HttpPatch]
        public async Task<IActionResult> UpdatePhotoByIdAsync(UpdatePhotoRequest request)
        {
            try
            {
                await _photosService.UpdatePhotoAsync(request.Id, request.AlbumId, request.Title, request.Url, request.ThumbnailUrl);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred during updating photo {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        [Route("delete_by_id")]
        [HttpDelete]
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
