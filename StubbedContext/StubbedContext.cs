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

        // Seed data for the AlbumEntity table
        modelBuilder.Entity<AlbumEntity>().HasData(
            new AlbumEntity { Id = 1, Name = "Album 1", CreationDate = new DateTime(2020, 1, 1), Visibility = Visibility.Public, CreatorId = 1 },
            new AlbumEntity { Id = 2, Name = "Album 2", CreationDate = new DateTime(2021, 2, 2), Visibility = Visibility.PrivateWeak, CreatorId = 2 },
            new AlbumEntity { Id = 3, Name = "Album 3", CreationDate = new DateTime(2022, 3, 3), Visibility = Visibility.Public, CreatorId = 3 }
        );

        // Seed data for the ContainsEntity table
        modelBuilder.Entity<ContainsEntity>().HasData(
            new ContainsEntity { Id = 1, AlbumId = 1, TrackId = 1, CustomTitle = "Custom Title 1" },
            new ContainsEntity { Id = 2, AlbumId = 1, TrackId = 2, CustomTitle = "Custom Title 2" },
            new ContainsEntity { Id = 3, AlbumId = 2, TrackId = 3, CustomTitle = "Custom Title 3" },
            new ContainsEntity { Id = 4, AlbumId = 2, TrackId = 4, CustomTitle = "Custom Title 4" },
            new ContainsEntity { Id = 5, AlbumId = 3, TrackId = 5, CustomTitle = "Custom Title 5" }
        );

        // Seed data for the UserEntity table
        modelBuilder.Entity<UserEntity>().HasData(
            new UserEntity { Id = 1, Username = "Admin", Role = Role.Admin },
            new UserEntity { Id = 2, Username = "User1", Role = Role.User },
            new UserEntity { Id = 3, Username = "User2", Role = Role.User }
        );

        // Seed data for the FriendEntity table
        modelBuilder.Entity<FriendEntity>().HasData(
            new FriendEntity { Id = 1, UserId = 2, FriendId = 3 },
            new FriendEntity { Id = 2, UserId = 3, FriendId = 2 }
        );
    }
}
