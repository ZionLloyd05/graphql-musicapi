using musicapi.Models;
using Microsoft.EntityFrameworkCore;

namespace musicapi.Data
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
    }
}