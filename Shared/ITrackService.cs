namespace Shared;

public interface ITrackService<TTrack> where TTrack : class
{
    public Task<TTrack> GetTrackFromIdAsync(long id);
}
