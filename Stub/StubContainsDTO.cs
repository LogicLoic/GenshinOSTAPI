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

    public Task<List<ContainsDTO>> GetAllContainsAsync() => Task.FromResult(ContainsList.ToList());

    public Task<ContainsDTO?> GetContainsFromIdAsync(long id)
    {
        return Task.FromResult(ContainsList.FirstOrDefault(c => c.Id == id));
    }

    public Task<ContainsDTO?> GetContainsAsync(long id, long albumId, long trackId)
    {
        var result = ContainsList.FirstOrDefault(c => c.Id == id && c.AlbumId == albumId && c.TrackId == trackId);
        return Task.FromResult(result);
    }

    public Task<ContainsDTO> CreateContainsAsync(ContainsDTO contains)
    {
        if (contains.Id <= 0 || ContainsList.Any(c => c.Id == contains.Id))
            contains.Id = ContainsList.Count == 0 ? 1 : ContainsList.Max(c => c.Id) + 1;

        ContainsList.Add(contains);
        return Task.FromResult(contains);
    }

    public Task<ContainsDTO?> UpdateContainsAsync(long id, ContainsDTO contains)
    {
        var index = ContainsList.FindIndex(c => c.Id == id);
        if (index < 0)
            return Task.FromResult<ContainsDTO?>(null);

        contains.Id = id;
        ContainsList[index] = contains;
        return Task.FromResult<ContainsDTO?>(contains);
    }

    public Task<bool> DeleteContainsAsync(long id)
    {
        var contains = ContainsList.FirstOrDefault(c => c.Id == id);
        return Task.FromResult(contains != null && ContainsList.Remove(contains));
    }
}
