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

    public Task<List<TrackDTO>> GetAllTracksAsync() => Task.FromResult(Tracks.ToList());

    public Task<TrackDTO?> GetTrackFromIdAsync(long id)
    {
        var track = Tracks.FirstOrDefault(t => t.Id == id);
        return Task.FromResult(track);
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

    public Task<TrackDTO> CreateTrackAsync(TrackDTO track)
    {
        if (track.Id <= 0 || Tracks.Any(t => t.Id == track.Id))
            track.Id = Tracks.Count == 0 ? 1 : Tracks.Max(t => t.Id) + 1;

        Tracks.Add(track);
        return Task.FromResult(track);
    }

    public Task<TrackDTO?> UpdateTrackAsync(long id, TrackDTO track)
    {
        var index = Tracks.FindIndex(t => t.Id == id);
        if (index < 0)
            return Task.FromResult<TrackDTO?>(null);

        track.Id = id;
        Tracks[index] = track;
        return Task.FromResult<TrackDTO?>(track);
    }

    public Task<bool> DeleteTrackAsync(long id)
    {
        var track = Tracks.FirstOrDefault(t => t.Id == id);
        return Task.FromResult(track != null && Tracks.Remove(track));
    }
}
