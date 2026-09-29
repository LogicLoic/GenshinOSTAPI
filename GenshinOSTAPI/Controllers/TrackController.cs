using Microsoft.AspNetCore.Mvc;
using DTOs;
using Shared;

namespace GenshinOSTAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly ILogger<TrackController> _logger;
        private ITrackService<TrackDTO> TrackService { get; set; }

        public TrackController(ILogger<TrackController> logger, ITrackService<TrackDTO> trackService)
        {
            _logger = logger;
            TrackService = trackService;
        }

        [HttpGet]
        public async Task<IEnumerable<TrackDTO>> GetAllTracksAsync()
        {
            return await TrackService.GetAllTracksAsync();
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetTrackFromIdAsync([FromRoute] long id)
        {
            var result = await TrackService.GetTrackFromIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("album/{albumId}")]
        public async Task<IEnumerable<TrackDTO>> GetAllTracksFromAlbumAsync([FromRoute] long albumId)
        {
            var result = await TrackService.GetAllTracksFromAlbumAsync(albumId);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrackAsync([FromBody] TrackDTO track)
        {
            var result = await TrackService.CreateTrackAsync(track);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrackAsync([FromRoute] long id, [FromBody] TrackDTO track)
        {
            var result = await TrackService.UpdateTrackAsync(id, track);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrackAsync([FromRoute] long id)
        {
            var deleted = await TrackService.DeleteTrackAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
