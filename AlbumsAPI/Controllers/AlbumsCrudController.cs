using Albums.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

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
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred during get albums {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        [HttpPost(Name = "CreateAlbum")]
        public async Task<IActionResult> CreateAlbumAsync(int id, int userId, string title)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred during get albums {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        [HttpPatch(Name = "UpdateAlbumById")]
        public async Task<IActionResult> UpdateAlbumByIdAsync(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred during get albums {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete(Name = "DeleteAlbumById")]
        public async Task<IActionResult> DeleteAlbumById(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred during get albums {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
