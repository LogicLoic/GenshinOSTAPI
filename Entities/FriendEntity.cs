namespace Entities;

public class FriendEntity
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long FriendId { get; set; }
    public FriendshipStrength Strength { get; set; }
}
