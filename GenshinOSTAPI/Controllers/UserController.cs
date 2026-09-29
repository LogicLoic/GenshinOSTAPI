using Microsoft.AspNetCore.Mvc;
using DTOs;
using Shared;

namespace GenshinOSTAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserService<UserDTO> UserService { get; set; }

        public UserController(ILogger<UserController> logger, IUserService<UserDTO> userService)
        {
            _logger = logger;
            UserService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            return await UserService.GetAllUsersAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            var user = await UserService.GetUserFromIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpGet("username/{username}")]
        public async Task<IEnumerable<UserDTO>> GetUserByUsername(string username)
        {
            var user = await UserService.GetUserFromUsernameAsync(username);
            return user != null ? new List<UserDTO> { user } : new List<UserDTO>();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserDTO user)
        {
            var result = await UserService.CreateUserAsync(user);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] long id, [FromBody] UserDTO user)
        {
            var result = await UserService.UpdateUserAsync(id, user);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] long id)
        {
            var deleted = await UserService.DeleteUserAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
