using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using musicapi.Data;
using musicapi.Models;
using musicapi.Models.DTOs;

namespace musicapi.GraphQL
{
    public class Mutation
    {
        /// <summary>
        /// create a new artist
        /// </summary>
        /// <param name="addArtistInput"></param>
        /// <param name="dbContext"></param>
        /// <returns>returns artist info</returns>
        [UseDbContext(typeof(MusicDbContext))]
        public async Task<AddArtistResponse> AddArtistAsync(
            AddArtistInput addArtistInput,
            [ScopedService] MusicDbContext dbContext
        )
        {
            var newArtist = new Artist
            {
                Name = addArtistInput.Name,
                DateJoined = DateTime.Now
            };

            dbContext.Artists.Add(newArtist);
            await dbContext.SaveChangesAsync();

            return new AddArtistResponse(newArtist);
        }

        /// <summary>
        /// create a song
        /// </summary>
        /// <param name="addSongInput"></param>
        /// <param name="dbContext"></param>
        /// <returns>return new song info</returns>
        [UseDbContext(typeof(MusicDbContext))]
        public async Task<AddSongResponse> AddSongAsync(
            AddSongInput addSongInput,
            [ScopedService] MusicDbContext dbContext)
        {
            //verify artist exist in db

            var newSong = new Song
            {
                Title = addSongInput.Title,
                Duration = addSongInput.Duration,
                ArtistId = addSongInput.ArtistId
            };

            dbContext.Songs.Add(newSong);
            await dbContext.SaveChangesAsync();

            return new AddSongResponse(newSong);
        }

        /// <summary>
        /// create a playlist
        /// </summary>
        /// <param name="createPlaylistInput"></param>
        /// <param name="dbContext"></param>
        /// <returns>return new playlist info</returns>
        [UseDbContext(typeof(MusicDbContext))]
        public async Task<CreatePlaylistResponse> CreatePlaylistAsync(
            CreatePlaylistInput createPlaylistInput,
            [ScopedService] MusicDbContext dbContext)
        {
            var songIds = createPlaylistInput.SongIds;

            var playlistSongs = await dbContext.Songs.Where(song
                => songIds.Contains(song.Id)).ToListAsync();

            var newPlaylist = new Playlist
            {
                Name = createPlaylistInput.Name,
                Songs = playlistSongs,
            };

            dbContext.Playlists.Add(newPlaylist);
            await dbContext.SaveChangesAsync();

            return new CreatePlaylistResponse(newPlaylist);
        }
    }
}