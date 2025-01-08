using Albums.Business.Services;
using Albums.Domain.Contracts;
using AlbumsAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

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
                if (request.Id == 0 || request.AlbumId == 0)
                    throw new ArgumentException("Invalid id for a photo or album id for album.");

                if (await _photosService.ValidatePhotoExist(request.Id))
                {
                    _logger.LogError($"Photo already exist for given album.");
                    throw new ArgumentException(nameof(request.AlbumId));
                }
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
                if (request.Id == 0 || request.AlbumId == 0)
                    throw new ArgumentException("Invalid id for photo or album id for album.");

                if (!await _photosService.ValidatePhotoExistInAlbum(request.Id, request.AlbumId))
                {
                    _logger.LogError($"Photo does not exist for given album., not update was done.");
                    throw new ArgumentException(nameof(request.AlbumId));
                }

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
                if (id == 0)
                    throw new ArgumentException("Invalid id for a photo.");

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
