namespace Shared;

public interface IAlbumService<TAlbum> where TAlbum : class
{
    public Task<TAlbum> GetAlbumFromIdAsync(long id);
    public Task<TAlbum> GetAlbumFromNameAsync(string name);
    public Task<List<TAlbum>> GetAlbumsFromCreatorAsync(string creator);
}
