namespace DAL.Mapping
{
    public static class Mapper
    {
        public static DbEntities.Game ToDb(Domain.Entities.Game domainGame) => 
            new (domainGame.SteamID, domainGame.UserNote, domainGame.SaleToNotify);

        public static DbEntities.Wishlist ToDb(Domain.Entities.Wishlist domainWishlist) => 
            new (domainWishlist.Id, domainWishlist.Name, domainWishlist.UserDescription);

        public static Domain.Entities.Game ToDomain(DbEntities.Game dbGame) => 
            new (dbGame.Id, dbGame.SteamID, dbGame.UserNote, dbGame.SaleToNotify);

        public static Domain.Entities.Wishlist ToDomain(DbEntities.Wishlist dbWishlist) => 
            new (dbWishlist.Id, dbWishlist.Name, dbWishlist.UserDescription);        
    }
}