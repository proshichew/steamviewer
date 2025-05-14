using Steamviewer.Services.Interfaces;
using Steamviewer.Entities;

namespace Steamviewer.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly HttpClient _httpClient;

        public WishlistService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Wishlist?> GetWishlistAsync(int id, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<Wishlist>($"api/Wishlist/{id}", ct);
        }

        public async Task AddWishlistAsync(Wishlist wishlistDto, CancellationToken ct = default)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Wishlist", wishlistDto, ct);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteWishlistAsync(int id, CancellationToken ct = default)
        {
            var response = await _httpClient.DeleteAsync($"api/Wishlist/{id}", ct);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddGameToWishlistAsync(int wishlistId, int gameId, CancellationToken ct = default)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Wishlist/InsertGame?wishlistId={wishlistId}&gameId={gameId}", new { }, ct);
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<Game>> GetWishlistGamesAsync(int wishlistId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Game>>($"api/Wishlist/GetAllGames?id={wishlistId}", ct)
                   ?? Enumerable.Empty<Game>();
        }

        public async Task RemoveGameFromWishlistAsync(int wishlistId, int gameId, CancellationToken ct = default)
        {
            var response = await _httpClient.DeleteAsync($"api/Wishlist/RemoveGame?wishlistId={wishlistId}&gameId={gameId}", ct);
            response.EnsureSuccessStatusCode();
        }
    }

}
