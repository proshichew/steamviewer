namespace Domain.Entities
{
    public class Wishlist
    {
        public int Id {  get; set; }
        public required string Name { get; set; }
        public string? UserDescription { get; set; }
        public List<Game> Games { get; set; } = [];
    }
}