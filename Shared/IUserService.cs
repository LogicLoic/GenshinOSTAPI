namespace Shared;

public interface IUserService<TUser> where TUser : class
{
    Task<TUser> GetUserFromIdAsync(long id);
    Task<TUser> GetUserFromUsernameAsync(string username);
}
