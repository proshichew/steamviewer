using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IWishlistRepository : IRepository<Wishlist>
    {
        Task<IEnumerable<Game>?> GetGames(Wishlist wishlist, CancellationToken cancellationToken);
        Task InsertGame(Wishlist wishlist, int gameId, CancellationToken cancellationToken);
        Task RemoveGame(Wishlist wishlist, int gameId, CancellationToken cancellationToken);
    }
}