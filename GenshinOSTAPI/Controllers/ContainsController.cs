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

        [HttpGet]
        public async Task<IEnumerable<ContainsDTO>> GetAllContainsAsync()
        {
            return await ContainsService.GetAllContainsAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContainsFromIdAsync([FromRoute] long id)
        {
            var result = await ContainsService.GetContainsFromIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("contains/{id}/{albumId}/{trackId}")]
        public async Task<IActionResult> GetContainsAsync([FromRoute] long id, [FromRoute] long albumId, [FromRoute] long trackId)
        {
            var result = await ContainsService.GetContainsAsync(id, albumId, trackId);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContainsAsync([FromBody] ContainsDTO contains)
        {
            var result = await ContainsService.CreateContainsAsync(contains);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContainsAsync([FromRoute] long id, [FromBody] ContainsDTO contains)
        {
            var result = await ContainsService.UpdateContainsAsync(id, contains);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContainsAsync([FromRoute] long id)
        {
            var deleted = await ContainsService.DeleteContainsAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
