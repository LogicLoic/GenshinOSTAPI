namespace Shared;

public interface IUserService<TUser> where TUser : class
{
    Task<List<TUser>> GetAllUsersAsync();
    Task<TUser?> GetUserFromIdAsync(long id);
    Task<TUser?> GetUserFromUsernameAsync(string username);
    Task<TUser> CreateUserAsync(TUser user);
    Task<TUser?> UpdateUserAsync(long id, TUser user);
    Task<bool> DeleteUserAsync(long id);
}
