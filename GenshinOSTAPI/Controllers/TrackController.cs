using Microsoft.AspNetCore.Http;
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
    }
}
