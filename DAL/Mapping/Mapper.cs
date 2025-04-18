namespace DAL.Mapping
{
    public class Mapper
    {
        public static DbEntities.Game ConvertToDb (Domain.Entities.Game domainGame)
        {
            return new DbEntities.Game(domainGame.Id, domainGame.SteamID, domainGame.UserNote, domainGame.SaleToNotify);
        }
        public static Domain.Entities.Game ConvertToDomain (DbEntities.Game dbGame)
        {
            return new Domain.Entities.Game(dbGame.Id, dbGame.SteamID, dbGame.UserNote, dbGame.SaleToNotify);
        }
    }
}