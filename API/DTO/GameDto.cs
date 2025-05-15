using DAL.DbEntities;

namespace API.DTO
{
    public record GameDto(
        int Id, 
        int SteamId, 
        string UserNote, 
        int SaleToNotify);
}