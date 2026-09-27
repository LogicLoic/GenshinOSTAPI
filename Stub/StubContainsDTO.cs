using Shared;
using DTOs;


namespace Stub;

public class StubContainsDTO : IContainsService<ContainsDTO>
{
    public static List<ContainsDTO> ContainsList = new()
    {
        new ContainsDTO { Id = 1, AlbumId = 1, TrackId = 1 },
        new ContainsDTO { Id = 2, AlbumId = 1, TrackId = 2 },
        new ContainsDTO { Id = 3, AlbumId = 2, TrackId = 3 },
        new ContainsDTO { Id = 4, AlbumId = 2, TrackId = 4 },
        new ContainsDTO { Id = 5, AlbumId = 3, TrackId = 5 }
    };
    public Task<ContainsDTO> GetContainsAsync(long id, long albumId, long trackId)
    {
        // For the stub, we can return a dummy ContainsDTO object
        var result = ContainsList.FirstOrDefault(c => c.Id == id && c.AlbumId == albumId && c.TrackId == trackId);
        return Task.FromResult<ContainsDTO>(result);
    }
}
