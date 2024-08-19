namespace musicapi.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateJoined { get; set; }
    }
}