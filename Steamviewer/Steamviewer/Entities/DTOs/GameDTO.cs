namespace Steamviewer.Entities.DTOs;

public record GameDTO(
    int Id, 
    int SteamId, 
    string UserNote, 
    int SaleToNotify);
