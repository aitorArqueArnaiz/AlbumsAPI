using Albums.Domain.Contracts;
using AlbumsAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace AlbumsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsCrudeController : ControllerBase
    {

        private readonly ILogger<AlbumsController> _logger;
        private readonly IAlbumsService _albumsService;

        public AlbumsCrudeController(
            ILogger<AlbumsController> logger,
            IAlbumsService albumsService)
        {
            _logger = logger;
            _albumsService = albumsService;
        }
        [Route("get_photo_by_id")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                _albumsService.GetAlbumByIdAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred during get album {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        [Route("create_new_albums")]
        [HttpPost]
        public async Task<IActionResult> CreateAlbumAsync(CreateAlbumRequest request)
        {
            try
            {
                var newAlbum = _albumsService.CreateAlbumAsync(request.Id, request.UserId, request.Title);
                return Ok(newAlbum);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred during create album {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        [Route("update_album_by_id")]
        [HttpPatch]
        public async Task<IActionResult> UpdateAlbumByIdAsync(UpdateAlbumRequest request)
        {
            try
            {
                await _albumsService.UpdateAlbumAsync(request.Id, request.UserId, request.Title);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred during updating album {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        [Route("delete_by_id")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAlbumById(int id)
        {
            try
            {
                await _albumsService.DeleteAlbumAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred during deleting album {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
