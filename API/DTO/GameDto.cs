namespace API.DTO
{
    public record GameDto
    {
        public GameDto(int id, int steamId, string? userNote, int saleToNotify)
        {
            Id = id;
            SteamID = steamId;
            UserNote = userNote;
            SaleToNotify = saleToNotify;
        }
        public int Id { get; }
        public int SteamID { get; }
        public string? UserNote { get; }
        public int SaleToNotify { get; }
    }
}