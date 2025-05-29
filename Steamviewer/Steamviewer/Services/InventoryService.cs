using Steamviewer.Entities.DTOs;
using Steamviewer.Services.Interfaces;

namespace Steamviewer.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly HttpClient _httpClient;
        
        public InventoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<InventoryDto?> GetByPlayerIdAsync(string playerId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<InventoryDto>($"api/inventory/{playerId}", ct);
        }
        public async Task<InventoryDto?> AddInventoryAsync(string playerId, CancellationToken ct = default)
        {
            var response = await _httpClient.PostAsJsonAsync("api/inventory", new {playerId}, ct);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadFromJsonAsync<InventoryDto>(ct);
        }

    }
}
