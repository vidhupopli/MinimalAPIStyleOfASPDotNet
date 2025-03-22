namespace MinimalAPI.Models
{
    public class Shirt
    {
        public required string ShirtId { get; set; }
        public required string Color { get; set; }
        public required string Size { get; set; }
        public string? Gender { get; set; }
        public required double Price { get; set; }
    }
}
