using DTOs;
using Shared;

namespace Stub;

public class StubUserDTO : IUserService<UserDTO>
{
    public static List<UserDTO> Users = new()
    {
        new UserDTO { Id = 1, Username = "Admin", Role = Role.Admin },
        new UserDTO { Id = 2, Username = "User1", Role = Role.User },
        new UserDTO { Id = 3, Username = "User2", Role = Role.User },
    };

    public Task<UserDTO> GetUserFromIdAsync(long id)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        return Task.FromResult<UserDTO>(user);
    }

    public Task<UserDTO> GetUserFromUsernameAsync(string username)
    {
        var user = Users.FirstOrDefault(u => u.Username == username);
        return Task.FromResult<UserDTO>(user);
    }
}
