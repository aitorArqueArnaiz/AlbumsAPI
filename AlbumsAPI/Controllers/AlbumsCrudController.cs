using Albums.Domain.Contracts;
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
        [HttpGet(Name = "GetAlbumById")]
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

        [HttpPost(Name = "CreateAlbum")]
        public async Task<IActionResult> CreateAlbumAsync(int id, int userId, string title)
        {
            try
            {
                var newAlbum = _albumsService.CreateAlbumAsync(id, userId, title);
                return Ok(newAlbum);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred during create album {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        [HttpPatch(Name = "UpdateAlbumById")]
        public async Task<IActionResult> UpdateAlbumByIdAsync(int id, int userId, string newTitle)
        {
            try
            {
                await _albumsService.UpdateAlbumAsync(id, userId, newTitle);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred during updating album {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete(Name = "DeleteAlbumById")]
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
