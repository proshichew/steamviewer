using Steamviewer.Entities.DTOs;
namespace Steamviewer.Services.Interfaces

{
    public interface IWishlistService
    {
        Task<WishlistDto?> GetWishlistAsync(int id, CancellationToken ct = default);
        Task AddWishlistAsync(WishlistDto wishlistDto, CancellationToken ct = default);
        Task DeleteWishlistAsync(int id, CancellationToken ct = default);
        Task AddGameToWishlistAsync(int wishlistId, GameDTO gameDto, CancellationToken ct = default);
        Task<IEnumerable<GameDTO>> GetWishlistGamesAsync(int wishlistId, CancellationToken ct = default);
        Task RemoveGameFromWishlistAsync(int wishlistId, int gameId, CancellationToken ct = default);

        Task<IEnumerable<WishlistDto>> GetAllAsync(CancellationToken ct = default);
    }
}
