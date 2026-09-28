namespace Shared;

public interface ITrackService<TTrack> where TTrack : class
{
    public Task<TTrack> GetTrackFromIdAsync(long id);
    public Task<List<TTrack>> GetAllTracksFromAlbumAsync(long albumId);
    public Task<TTrack> CreateTrackAsync(TTrack track);
    public Task<TTrack> UpdateTrackAsync(TTrack track);
    public Task DeleteTrackAsync(long id);
}
