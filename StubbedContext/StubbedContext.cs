using Entities;
using Microsoft.EntityFrameworkCore;

namespace StubbedContext;

public class StubbedContext : GenshinOSTContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data for the TrackEntity table
        modelBuilder.Entity<TrackEntity>().HasData(
            new TrackEntity { Id = 1, Title = "Track 1", Artist = "Artist 1", Duration = 180, Rating = 4.5 },
            new TrackEntity { Id = 2, Title = "Track 2", Artist = "Artist 2", Duration = 200, Rating = 4.0 },
            new TrackEntity { Id = 3, Title = "Track 3", Artist = "Artist 3", Duration = 240, Rating = 5.0 },
            new TrackEntity { Id = 4, Title = "Track 4", Artist = "Artist 4", Duration = 210, Rating = 3.5 },
            new TrackEntity { Id = 5, Title = "Track 5", Artist = "Artist 5", Duration = 190, Rating = 4.2 }
        );
    }
}
