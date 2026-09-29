namespace Shared;

public interface IAlbumService<TAlbum> where TAlbum : class
{
    public Task<List<TAlbum>> GetAllAlbumsAsync();
    public Task<TAlbum?> GetAlbumFromIdAsync(long id);
    public Task<TAlbum?> GetAlbumFromNameAsync(string name);
    public Task<List<TAlbum>> GetAlbumsFromCreatorAsync(string creator);
    public Task<TAlbum> CreateAlbumAsync(TAlbum album);
    public Task<TAlbum?> UpdateAlbumAsync(long id, TAlbum album);
    public Task<bool> DeleteAlbumAsync(long id);
}
