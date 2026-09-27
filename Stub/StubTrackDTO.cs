using Shared;
using DTOs;

namespace Stub;

public class StubTrackDTO : ITrackService<TrackDTO>
{
    public static List<TrackDTO> Tracks = new()
    {
        new TrackDTO { Id = 1, Title = "Track 1", Artist = "Artist 1", Duration = 180, Rating = 4.5 },
        new TrackDTO { Id = 2, Title = "Track 2", Artist = "Artist 2", Duration = 200, Rating = 4.0 },
        new TrackDTO { Id = 3, Title = "Track 3", Artist = "Artist 3", Duration = 240, Rating = 5.0 },
        new TrackDTO { Id = 4, Title = "Track 4", Artist = "Artist 4", Duration = 210, Rating = 3.5 },
        new TrackDTO { Id = 5, Title = "Track 5", Artist = "Artist 5", Duration = 190, Rating = 4.2 }
    };

    public Task<TrackDTO> GetTrackFromIdAsync(long id)
    {
        var track = Tracks.FirstOrDefault(t => t.Id == id);
        return Task.FromResult<TrackDTO>(track);
    }

public Task<List<TrackDTO>> GetAllTracksFromAlbumAsync(long albumId)
{
    var tracks = StubContainsDTO.ContainsList
        .Where(c => c.AlbumId == albumId)
        .Join(
            Tracks,
            c => c.TrackId,
            t => t.Id,
            (c, t) => t
        )
        .ToList();

    return Task.FromResult(tracks);
}
}
