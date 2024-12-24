using Albums.Business.Services;
using Albums.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace AlbumsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : Controller
    {

        private readonly ILogger<AlbumsController> _logger;
        private readonly IAlbumsService _albumsService;

        public AlbumsController(
            ILogger<AlbumsController> logger,
            IAlbumsService albumsService)
        {
            _logger = logger;
            _albumsService = albumsService;
        }

        [HttpPost(Name = "SaveAlbumsAndPhotos")]
        [EndpointName("SaveAlbumsAndPhotos")]
        public async Task<IActionResult> Save()
        {
            try
            {
                await _albumsService.SaveAlbumsAndPhotosAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred during saving albums and photos {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        [HttpGet(Name = "GetFilteredAlbums")]
        [EndpointName("GetAlbumsFilteredByTitle")]
        public async Task<IActionResult> GetByTitleAsync(string title)
        {
            try
            {
                var response = await _albumsService.GetAlbumsFilteredByTitleAsync(title);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred during get albums {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
