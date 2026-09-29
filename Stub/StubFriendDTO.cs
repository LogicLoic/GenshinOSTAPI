using DTOs;
using Shared;

namespace Stub;

public class StubFriendDTO : IFriendService<FriendDTO>
{
    public static List<FriendDTO> Friends { get; set; } = new()
    {
        new FriendDTO
        {
            Id = 1,
            UserId = 1,
            FriendId = 2
        },
        new FriendDTO
        {
            Id = 2,
            UserId = 1,
            FriendId = 3
        }
    };

    public Task<List<FriendDTO>> GetFriendsAsync(long userId)
    {
        var friends = Friends
            .Where(f => f.UserId == userId || f.FriendId == userId)
            .ToList();

        return Task.FromResult(friends);
    }

    public Task<FriendDTO?> GetFriendAsync(long userId, long friendId)
    {
        var friend = Friends.FirstOrDefault(f =>
            (f.UserId == userId && f.FriendId == friendId) ||
            (f.UserId == friendId && f.FriendId == userId));

        return Task.FromResult(friend);
    }

    public Task<FriendDTO> AddFriendAsync(long userId, long friendId)
    {
        var existingFriend = Friends.FirstOrDefault(f =>
            (f.UserId == userId && f.FriendId == friendId) ||
            (f.UserId == friendId && f.FriendId == userId));

        if (existingFriend != null)
            return Task.FromResult(existingFriend);

        var newFriend = new FriendDTO
        {
            Id = Friends.Count == 0 ? 1 : Friends.Max(f => f.Id) + 1,
            UserId = userId,
            FriendId = friendId
        };

        Friends.Add(newFriend);

        return Task.FromResult(newFriend);
    }

    public Task<bool> RemoveFriendAsync(long userId, long friendId)
    {
        var friend = Friends.FirstOrDefault(f =>
            (f.UserId == userId && f.FriendId == friendId) ||
            (f.UserId == friendId && f.FriendId == userId));

        if (friend == null)
            return Task.FromResult(false);

        Friends.Remove(friend);
        return Task.FromResult(true);
    }

    public Task<bool> IsFriendAsync(long userId, long friendId)
    {
        var isFriend = Friends.Any(f =>
            (f.UserId == userId && f.FriendId == friendId) ||
            (f.UserId == friendId && f.FriendId == userId));

        return Task.FromResult(isFriend);
    }
}