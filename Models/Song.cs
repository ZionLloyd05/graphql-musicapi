namespace musicapi.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public int ArtistId { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; }
        public virtual Artist Artist { get; set; }
    }
}