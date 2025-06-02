using Steamviewer.Entities.DTOs;
using Steamviewer.Services.Interfaces;

namespace Steamviewer.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly HttpClient _httpClient;
        public InventoryService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<IEnumerable<InventoryDto>> GetAllAsync(CancellationToken ct = default)
            => await _httpClient.GetFromJsonAsync<IEnumerable<InventoryDto>>("api/inventory", ct) ?? [];

        public async Task<InventoryDto?> GetByPlayerIdAsync(string playerId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<InventoryDto>($"api/inventory/{playerId}", ct);
        }

        public async Task<InventoryDto?> AddInventoryAsync(string playerId, CancellationToken ct = default)
        {
            var response = await _httpClient.PostAsJsonAsync("api/inventory/create", playerId, ct);
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadFromJsonAsync<InventoryDto>(ct);
        }

        public async Task<IEnumerable<ItemDto>> GetInventoryItemsAsync(int inventoryId, CancellationToken ct = default)
            => await _httpClient.GetFromJsonAsync<IEnumerable<ItemDto>>($"api/inventory/{inventoryId}/items", ct) ?? [];

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            await _httpClient.DeleteAsync($"api/inventory/{id}", ct);
        }
    }
}
