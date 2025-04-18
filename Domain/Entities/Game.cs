namespace Domain.Entities
{
    public class Game (int id, int steamID, string? userNote, int saleToNotify)
    {
        public int Id { get; set; } = id;
        public int SteamID {  get; set; } = steamID;
        public string? UserNote { get; set; } = userNote;
        public int SaleToNotify { get; set; } = saleToNotify;
    }
}