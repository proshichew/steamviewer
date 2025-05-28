namespace Domain.Entities
{
    public class Game (int steamID, string? userNote, int saleToNotify)
    {
        public int Id { get; set; }
        public int SteamID {  get; set; } = steamID;
        public string? UserNote { get; set; } = userNote;
        public int SaleToNotify { get; set; } = saleToNotify;
    }
}