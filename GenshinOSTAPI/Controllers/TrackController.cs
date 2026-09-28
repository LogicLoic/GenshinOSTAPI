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

        [HttpGet ("{id}")]
        public async Task<IEnumerable<TrackDTO>> GetTrackFromIdAsync([FromRoute] long id)
        {
            var result = await TrackService.GetTrackFromIdAsync(id);
            return result != null ? new List<TrackDTO> { result } : new List<TrackDTO>();
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
            track.Id = id;
            var result = await TrackService.UpdateTrackAsync(track);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrackAsync([FromRoute] long id)
        {
            await TrackService.DeleteTrackAsync(id);
            return Ok();
        }
    }
}
