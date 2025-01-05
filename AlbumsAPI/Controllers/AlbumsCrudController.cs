using Albums.Domain.Contracts;
using AlbumsAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.ComponentModel;

namespace AlbumsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsCrudController : ControllerBase
    {

        private readonly ILogger<AlbumsController> _logger;
        private readonly IAlbumsService _albumsService;

        public AlbumsCrudController(
            ILogger<AlbumsController> logger,
            IAlbumsService albumsService)
        {
            _logger = logger;
            _albumsService = albumsService;
        }
        [Route("get_album_by_id")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var album = _albumsService.GetAlbumByIdAsync(id);
                return Ok(album);
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
                if (request.Id == 0 || request.UserId == 0)
                    throw new ArgumentException("Invalid id for an album or user id for user.");

                if (await _albumsService.ValidateAlbumUserExistsAsync(request.Id, request.UserId))
                {
                    _logger.LogError($"Album already exist for given user.");
                    throw new ArgumentException(nameof(request.UserId));
                }

                await _albumsService.CreateAlbumAsync(request.Id, request.UserId, request.Title);
                return Ok();
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
                if (request.Id == 0 || request.UserId == 0)
                    throw new ArgumentException("Invalid id for an album or user id for user.");

                if (!await _albumsService.ValidateAlbumUserExistsAsync(request.Id, request.UserId))
                {
                    _logger.LogError($"Album does not exist for given user., not update was done.");
                    throw new ArgumentException(nameof(request.UserId));
                }

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
                if(id == 0)
                    throw new ArgumentException("Invalid id for an album.");

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
