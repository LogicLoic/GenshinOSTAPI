namespace Shared;

public interface IContainsService<TContains> where TContains : class
{
    public Task<List<TContains>> GetAllContainsAsync();
    public Task<TContains?> GetContainsFromIdAsync(long id);
    public Task<TContains?> GetContainsAsync(long id, long albumId, long trackId);
    public Task<TContains> CreateContainsAsync(TContains contains);
    public Task<TContains?> UpdateContainsAsync(long id, TContains contains);
    public Task<bool> DeleteContainsAsync(long id);
}
