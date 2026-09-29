namespace Shared;

public interface IFriendService<TFriend> where TFriend : class
{
    Task<List<TFriend>> GetFriendsAsync(long userId);
    Task<TFriend?> GetFriendAsync(long userId, long friendId);
    Task<TFriend> AddFriendAsync(long userId, long friendId);
    Task<bool> RemoveFriendAsync(long userId, long friendId);
    Task<bool> IsFriendAsync(long userId, long friendId);
}
