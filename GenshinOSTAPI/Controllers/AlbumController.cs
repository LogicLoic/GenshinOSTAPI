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

        [HttpGet("{id}")]
        public async Task<IEnumerable<AlbumDTO>> GetAlbumFromIdAsync([FromRoute] long id)
        {
            var result = await AlbumService.GetAlbumFromIdAsync(id);
            return result != null ? new List<AlbumDTO> { result } : new List<AlbumDTO>();
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
    }
}
