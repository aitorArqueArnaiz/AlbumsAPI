using Microsoft.AspNetCore.Mvc;

namespace AlbumsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : ControllerBase
    {

        private readonly ILogger<AlbumsController> _logger;

        public AlbumsController(ILogger<AlbumsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
