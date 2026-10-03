namespace Entities;

public class TrackEntity
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public string? Artist { get; set; }
    public long Duration { get; set; }
    public double Rating { get; set; }
}
