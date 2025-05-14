namespace Domain.Entities
{
    public class Wishlist (string name, string? userDescription)
    {

        public int Id { get; set; }
        public string Name { get; set; } = name;
        public string? UserDescription { get; set; } = userDescription;
        public List<Game> Games { get; set; } = [];
    }
}