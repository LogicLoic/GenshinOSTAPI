using Microsoft.AspNetCore.Mvc;
using DTOs;
using Shared;

namespace GenshinOSTAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly ILogger<AlbumController> _logger;
        private IAlbumService<AlbumDTO> AlbumService { get; set; }

        public AlbumController(ILogger<AlbumController> logger, IAlbumService<AlbumDTO> albumService)
        {
            _logger = logger;
            AlbumService = albumService;
        }

        [HttpGet]
        public async Task<IEnumerable<AlbumDTO>> GetAllAlbumsAsync()
        {
            return await AlbumService.GetAllAlbumsAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbumFromIdAsync([FromRoute] long id)
        {
            var result = await AlbumService.GetAlbumFromIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("name/{name}")]
        public async Task<IEnumerable<AlbumDTO>> GetAlbumFromNameAsync([FromRoute] string name)
        {
            var result = await AlbumService.GetAlbumFromNameAsync(name);
            return result != null ? new List<AlbumDTO> { result } : new List<AlbumDTO>();
        }

        [HttpGet("creator/{creator}")]
        public async Task<IEnumerable<AlbumDTO>> GetAlbumsFromCreatorAsync([FromRoute] string creator)
        {
            var result = await AlbumService.GetAlbumsFromCreatorAsync(creator);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlbumAsync([FromBody] AlbumDTO album)
        {
            var result = await AlbumService.CreateAlbumAsync(album);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlbumAsync([FromRoute] long id, [FromBody] AlbumDTO album)
        {
            var result = await AlbumService.UpdateAlbumAsync(id, album);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbumAsync([FromRoute] long id)
        {
            var deleted = await AlbumService.DeleteAlbumAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
