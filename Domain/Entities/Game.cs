namespace Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public int SteamID {  get; set; }
        public string? UserNote { get; set; }
        public int SaleToNotify { get; set; }
    }
}