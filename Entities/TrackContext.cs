using Microsoft.EntityFrameworkCore;

namespace Entities;

public class GenshinOSTContext : DbContext
{
    public GenshinOSTContext()
    { }

    public GenshinOSTContext(DbContextOptions<GenshinOSTContext> options)
        : base(options)
    { }
    public DbSet<TrackEntity> Tracks { get; set; }
    public DbSet<AlbumEntity> Albums { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ContainsEntity> Contains { get; set; }
    public DbSet<FriendEntity> Friends { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
{
    if (!options.IsConfigured)
        {
            options.UseSqlite("Data Source=genshin.ost.db");
        }
    }
}
