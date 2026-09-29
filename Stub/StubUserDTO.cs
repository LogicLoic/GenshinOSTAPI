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

    public Task<List<UserDTO>> GetAllUsersAsync() => Task.FromResult(Users.ToList());

    public Task<UserDTO?> GetUserFromIdAsync(long id)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        return Task.FromResult(user);
    }

    public Task<UserDTO?> GetUserFromUsernameAsync(string username)
    {
        var user = Users.FirstOrDefault(u => u.Username == username);
        return Task.FromResult(user);
    }

    public Task<UserDTO> CreateUserAsync(UserDTO user)
    {
        if (user.Id <= 0 || Users.Any(u => u.Id == user.Id))
            user.Id = Users.Count == 0 ? 1 : Users.Max(u => u.Id) + 1;

        Users.Add(user);
        return Task.FromResult(user);
    }

    public Task<UserDTO?> UpdateUserAsync(long id, UserDTO user)
    {
        var index = Users.FindIndex(u => u.Id == id);
        if (index < 0)
            return Task.FromResult<UserDTO?>(null);

        user.Id = id;
        Users[index] = user;
        return Task.FromResult<UserDTO?>(user);
    }

    public Task<bool> DeleteUserAsync(long id)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        return Task.FromResult(user != null && Users.Remove(user));
    }
}
