namespace DAL.Mapping
{
    public static class Mapper
    {
        public static DbEntities.Game ToDb(Domain.Entities.Game domainGame) => 
            new (domainGame.Id, domainGame.SteamID, domainGame.UserNote, domainGame.SaleToNotify);

        public static Domain.Entities.Game ToDomain(DbEntities.Game dbGame) => 
            new(dbGame.Id, dbGame.SteamID, dbGame.UserNote, dbGame.SaleToNotify);
    }
}