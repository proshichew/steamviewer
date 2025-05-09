namespace Steamviewer.Entities;

public record Game(
    int Id, 
    int SteamId, 
    string UserNote, 
    int SaleToNotify);