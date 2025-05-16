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

        public async Task<WishlistDto?> GetWishlistAsync(int id, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<WishlistDto>($"api/Wishlist/{id}", ct);
        }

        public async Task AddWishlistAsync(WishlistDto wishlistDto, CancellationToken ct = default)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Wishlist", wishlistDto, ct);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteWishlistAsync(int id, CancellationToken ct = default)
        {
            var response = await _httpClient.DeleteAsync($"api/Wishlist/{id}", ct);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddGameToWishlistAsync(int wishlistId, Game gameDto, CancellationToken ct = default)
        {
            var response = await _httpClient.PostAsJsonAsync(
                $"api/wishlist/{wishlistId}/games",
                gameDto,
                ct);
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<Game>> GetWishlistGamesAsync(int wishlistId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Game>>($"api/wishlist/{wishlistId}/games", ct)
                   ?? Enumerable.Empty<Game>();
        }

        public async Task RemoveGameFromWishlistAsync(int wishlistId, int gameId, CancellationToken ct = default)
        {
            var response = await _httpClient.DeleteAsync($"api/Wishlist/{wishlistId}/games/{gameId}", ct);
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<WishlistDto>> GetAllAsync(CancellationToken cts = default)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<WishlistDto>>("api/wishlist", cts);
        }

    }

}
