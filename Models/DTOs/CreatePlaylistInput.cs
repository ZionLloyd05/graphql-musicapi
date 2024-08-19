namespace musicapi.Models.DTOs
{
    public record CreatePlaylistInput(
        string Name, ICollection<int> SongIds);
}
