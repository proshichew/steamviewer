using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IWishlistRepository : IRepository<Wishlist>
    {
        Task<IEnumerable<Game>?> GetGames(int wishlist, CancellationToken cancellationToken);
        Task InsertGame(int wishlist, int gameId, CancellationToken cancellationToken);
        Task RemoveGame(int wishlist, int gameId, CancellationToken cancellationToken);
        Task InsertGame(int wishlistId, Game game, CancellationToken cancellationToken = default);
    }
}