using HotChocolate;
using HotChocolate.Data;
using musicapi.Data;
using musicapi.Models;

namespace musicapi.GraphQL
{
    public class Query
    {
        /// <summary>
        /// Artist query resolver
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        [UseDbContext(typeof(MusicDbContext))]
        public IQueryable<Artist> GetArtists(
            [ScopedService] MusicDbContext dbContext)
        {
            return dbContext.Artists;
        }

        /// <summary>
        /// Song query resolver
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        [UseDbContext(typeof(MusicDbContext))]
        [UseProjection]
        public IQueryable<Song> GetSongs(
            [ScopedService] MusicDbContext dbContext)
        {
            return dbContext.Songs;
        }

        /// <summary>
        /// Playlist query resolver
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        [UseDbContext(typeof(MusicDbContext))]
        [UseProjection]
        public IQueryable<Playlist> GetPlaylists(
            [ScopedService] MusicDbContext dbContext)
        {
            return dbContext.Playlists;
        }
    }
}
