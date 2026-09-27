namespace Shared;

public interface IAlbumService<TAlbum> where TAlbum : class
{
    public Task<TAlbum> GetAlbumFromIdAsync(long id);
}
