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

        [HttpGet("{id}")]
        public async Task<IEnumerable<UserDTO>> GetUserById(long id)
        {
            var user = await UserService.GetUserFromIdAsync(id);
            return user != null ? new List<UserDTO> { user } : new List<UserDTO>();
        }

        [HttpGet("username/{username}")]
        public async Task<IEnumerable<UserDTO>> GetUserByUsername(string username)
        {
            var user = await UserService.GetUserFromUsernameAsync(username);
            return user != null ? new List<UserDTO> { user } : new List<UserDTO>();
        }
    }
}
