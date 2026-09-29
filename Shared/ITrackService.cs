namespace Shared;

public interface ITrackService<TTrack> where TTrack : class
{
    public Task<List<TTrack>> GetAllTracksAsync();
    public Task<TTrack?> GetTrackFromIdAsync(long id);
    public Task<List<TTrack>> GetAllTracksFromAlbumAsync(long albumId);
    public Task<TTrack> CreateTrackAsync(TTrack track);
    public Task<TTrack?> UpdateTrackAsync(long id, TTrack track);
    public Task<bool> DeleteTrackAsync(long id);
}
