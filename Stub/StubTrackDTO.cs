using System;
using Shared;
using DTOs;

namespace Stub;

public class StubTrackDTO : ITrackService<TrackDTO>
{
    public static List<TrackDTO> Tracks = new()
    {
        new TrackDTO { Id = 1, Title = "Track 1", Artist = "Artist 1", Duration = 180, Rating = 4.5 },
        new TrackDTO { Id = 2, Title = "Track 2", Artist = "Artist 2", Duration = 200, Rating = 4.0 },
        new TrackDTO { Id = 3, Title = "Track 3", Artist = "Artist 3", Duration = 240, Rating = 5.0 }
    };

    public Task<TrackDTO> GetTrackFromIdAsync(long id)
    {
        var track = Tracks.FirstOrDefault(t => t.Id == id);
        return Task.FromResult<TrackDTO>(track);
    }
}
