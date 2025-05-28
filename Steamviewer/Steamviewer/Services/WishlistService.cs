using Steamviewer.Services.Interfaces;
using Steamviewer.Entities.DTOs;

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
            var response = await _httpClient.PostAsJsonAsync("api/wishlist", wishlistDto, ct);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteWishlistAsync(int id, CancellationToken ct = default)
        {
            var response = await _httpClient.DeleteAsync($"api/wishlist/{id}", ct);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddGameToWishlistAsync(int wishlistId, GameDTO gameDto, CancellationToken ct = default)
        {
            var response = await _httpClient.PostAsJsonAsync(
                $"api/wishlist/{wishlistId}/games",
                gameDto,
                ct);
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<GameDTO>> GetWishlistGamesAsync(int wishlistId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<GameDTO>>($"api/wishlist/{wishlistId}/games", ct)
                   ?? Enumerable.Empty<GameDTO>();
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
