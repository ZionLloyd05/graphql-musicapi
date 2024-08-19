namespace musicapi.Models.DTOs
{
    public record AddSongInput(
        string Title,
        string Duration,
        int ArtistId);
}
