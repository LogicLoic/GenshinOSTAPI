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
    }
}
