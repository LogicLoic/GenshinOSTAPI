using Shared;
using DTOs;


namespace Stub;

public class StubAlbumDTO : IAlbumService<AlbumDTO>
{
    public static List<AlbumDTO> AlbumList = new()
    {
        new AlbumDTO { Id = 1, Name = "Album 1", CreationDate = new DateTime(2020, 1, 1), Visibility = Visibility.Public, CreatorId = 1 },
        new AlbumDTO { Id = 2, Name = "Album 2", CreationDate = new DateTime(2021, 2, 2), Visibility = Visibility.Private, CreatorId = 2 },
        new AlbumDTO { Id = 3, Name = "Album 3", CreationDate = new DateTime(2022, 3, 3), Visibility = Visibility.Public, CreatorId = 3 }
    };

    public Task<List<AlbumDTO>> GetAllAlbumsAsync() => Task.FromResult(AlbumList.ToList());

    public Task<AlbumDTO?> GetAlbumFromIdAsync(long id)
    {
        var album = AlbumList.FirstOrDefault(a => a.Id == id);
        return Task.FromResult(album);
    }

    public Task<AlbumDTO?> GetAlbumFromNameAsync(string name)
    {
        var album = AlbumList.FirstOrDefault(a => a.Name == name);
        return Task.FromResult(album);
    }

    public Task<List<AlbumDTO>> GetAlbumsFromCreatorAsync(string creator)
    {
        var user = StubUserDTO.Users.FirstOrDefault(u => u.Username == creator);

        if (user == null)
            return Task.FromResult(new List<AlbumDTO>());

        var albums = AlbumList.Where(a => a.CreatorId == user.Id).ToList();

        return Task.FromResult(albums);
    }

    public Task<AlbumDTO> CreateAlbumAsync(AlbumDTO album)
    {
        if (album.Id <= 0 || AlbumList.Any(a => a.Id == album.Id))
            album.Id = AlbumList.Count == 0 ? 1 : AlbumList.Max(a => a.Id) + 1;

        AlbumList.Add(album);
        return Task.FromResult(album);
    }

    public Task<AlbumDTO?> UpdateAlbumAsync(long id, AlbumDTO album)
    {
        var index = AlbumList.FindIndex(a => a.Id == id);
        if (index < 0)
            return Task.FromResult<AlbumDTO?>(null);

        album.Id = id;
        AlbumList[index] = album;
        return Task.FromResult<AlbumDTO?>(album);
    }

    public Task<bool> DeleteAlbumAsync(long id)
    {
        var album = AlbumList.FirstOrDefault(a => a.Id == id);
        return Task.FromResult(album != null && AlbumList.Remove(album));
    }

}
