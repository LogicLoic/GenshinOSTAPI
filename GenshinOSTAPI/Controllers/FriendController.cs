using Microsoft.AspNetCore.Mvc;
using DTOs;
using Shared;

namespace GenshinOSTAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService<FriendDTO> _friendService;

        public FriendController(IFriendService<FriendDTO> friendService)
        {
            _friendService = friendService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetFriendsAsync([FromRoute] long userId)
        {
            var friends = await _friendService.GetFriendsAsync(userId);
            return Ok(friends);
        }

        [HttpGet("{userId}/{friendId}")]
        public async Task<IActionResult> GetFriendAsync([FromRoute] long userId, [FromRoute] long friendId)
        {
            var friend = await _friendService.GetFriendAsync(userId, friendId);
            return friend == null ? NotFound() : Ok(friend);
        }

        [HttpPost("{userId}/{friendId}")]
        public async Task<IActionResult> AddFriendAsync([FromRoute] long userId, [FromRoute] long friendId)
        {
            var friend = await _friendService.AddFriendAsync(userId, friendId);
            return Ok(friend);
        }

        [HttpDelete("{userId}/{friendId}")]
        public async Task<IActionResult> RemoveFriendAsync([FromRoute] long userId, [FromRoute] long friendId)
        {
            var removed = await _friendService.RemoveFriendAsync(userId, friendId);
            return removed ? NoContent() : NotFound();
        }

        [HttpGet("isfriend/{userId}/{friendId}")]
        public async Task<IActionResult> IsFriendAsync([FromRoute] long userId, [FromRoute] long friendId)
        {
            var isFriend = await _friendService.IsFriendAsync(userId, friendId);
            return Ok(isFriend);
        }
    }
}