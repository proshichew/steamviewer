namespace DAL.Mapping
{
    public static class Mapper
    {
        public static DbEntities.Game ToDb(Domain.Entities.Game domainGame) => 
            new (domainGame.SteamID, domainGame.UserNote, domainGame.SaleToNotify);

        public static DbEntities.Wishlist ToDb(Domain.Entities.Wishlist domainWishlist) => 
            new (domainWishlist.Id, domainWishlist.Name, domainWishlist.UserDescription);

        public static Domain.Entities.Game ToDomain(DbEntities.Game dbGame) =>
            new (dbGame.SteamID, dbGame.UserNote, dbGame.SaleToNotify)
            {
                Id = dbGame.Id
            };

        public static Domain.Entities.Wishlist ToDomain(DbEntities.Wishlist dbWishlist) =>
            new (dbWishlist.Name, dbWishlist.UserDescription)
            {
                Id = dbWishlist.Id
            };
        public static DbEntities.Item ToDb(Domain.Entities.Item domainItem) =>
                    new(domainItem.Name, domainItem.Price, domainItem.Image, domainItem.Color, domainItem.Link)
                    {
                        Id = domainItem.Id
                    };

        public static Domain.Entities.Item ToDomain(DbEntities.Item dbItem) =>
            new(dbItem.Name, dbItem.Price, dbItem.Image, dbItem.Color, dbItem.Link)
            {
                Id = dbItem.Id
            };
        public static DbEntities.Inventory ToDb(Domain.Entities.Inventory domainInventory) =>
            new(domainInventory.Name, domainInventory.PlayerId, domainInventory.GameName)
            {
                Id = domainInventory.Id,
                Items = domainInventory.Items?.Select(ToDb).ToList() ?? new()
            };

        public static Domain.Entities.Inventory ToDomain(DbEntities.Inventory dbInventory) =>
            new(dbInventory.Name, dbInventory.PlayerId, dbInventory.GameName)
            {
                Id = dbInventory.Id,
                Items = dbInventory.Items?.Select(ToDomain).ToList() ?? new()
            };
    }
}