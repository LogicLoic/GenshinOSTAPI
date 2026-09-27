namespace Shared;

public interface IContainsService<TContains> where TContains : class
{
    public Task<TContains> GetContainsAsync(long id, long albumId, long trackId);
}
