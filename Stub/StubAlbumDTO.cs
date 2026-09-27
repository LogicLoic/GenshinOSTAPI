using Shared;
using DTOs;


namespace Shared;

public class StubAlbumDTO : IAlbumService<AlbumDTO>
{
    public static List<AlbumDTO> AlbumList = new()
    {
        new AlbumDTO { Id = 1, Name = "Album 1", CreationDate = new DateTime(2020, 1, 1), Visibility = Visibility.Public, CreatorId = 1 },
        new AlbumDTO { Id = 2, Name = "Album 2", CreationDate = new DateTime(2021, 2, 2), Visibility = Visibility.Private, CreatorId = 2 },
        new AlbumDTO { Id = 3, Name = "Album 3", CreationDate = new DateTime(2022, 3, 3), Visibility = Visibility.Public, CreatorId = 3 }
    };

    public Task<AlbumDTO> GetAlbumFromIdAsync(long id)
    {
        var album = AlbumList.FirstOrDefault(a => a.Id == id);
        return Task.FromResult<AlbumDTO>(album);
    }

}
