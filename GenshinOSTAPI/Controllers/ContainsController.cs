using Microsoft.AspNetCore.Mvc;
using DTOs;
using Shared;

namespace GenshinOSTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainsController : ControllerBase
    {
        private readonly ILogger<ContainsController> _logger;
        private IContainsService<ContainsDTO> ContainsService { get; set; }

        public ContainsController(ILogger<ContainsController> logger, IContainsService<ContainsDTO> containsService)
        {
            _logger = logger;
            ContainsService = containsService;
        }

        [HttpGet("contains/{id}/{albumId}/{trackId}")]
        public async Task<IEnumerable<ContainsDTO>> GetContainsAsync([FromRoute] long id, [FromRoute] long albumId, [FromRoute] long trackId)
        {
            var result = await ContainsService.GetContainsAsync(id, albumId, trackId);
            return result != null ? new List<ContainsDTO> { result } : new List<ContainsDTO>();
        }
    }
}
