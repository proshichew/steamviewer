using System.Text.Json;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace API.Services
{
    public class InventoryService(IInventoryRepository repository, HttpClient httpClient, IMapper mapper) : IInventoryService
    {
        private readonly IInventoryRepository _repository = repository;
        private readonly HttpClient _httpClient = httpClient;
        private readonly IMapper _mapper = mapper;
        private readonly string _steamApiKey = "S5V8KS0B67YK012U";

        public async Task<IEnumerable<Inventory>> GetAllAsync(CancellationToken ct = default)
            => await _repository.GetAll(ct);

        public async Task<Inventory?> GetByPlayerIdAsync(string playerId, CancellationToken ct = default)
            => await _repository.GetByPlayerId(playerId, ct);

        public async Task<Inventory?> CreateInventoryAsync(string playerId, CancellationToken ct = default)
        {
            var existing = await _repository.GetByPlayerId(playerId, ct);
            if (existing != null)
                return existing;

            var url = $"https://www.steamwebapi.com/steam/api/inventory?key={_steamApiKey}&steam_id={playerId}";
            var response = await _httpClient.GetAsync(url, ct);
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync(ct);

            using var doc = JsonDocument.Parse(json);
            var items = new List<Item>();

            if (doc.RootElement.ValueKind == JsonValueKind.Array)
            {
                foreach (var itemElement in doc.RootElement.EnumerateArray())
                {
                    var name = itemElement.GetProperty("marketname").GetString() ?? string.Empty;
                    var price = itemElement.TryGetProperty("priceavg", out var priceProperty) &&
                                priceProperty.ValueKind == JsonValueKind.Number
                        ? priceProperty.GetDecimal() : 0m;
                    var image = itemElement.GetProperty("image").GetString() ?? string.Empty;
                    var color = itemElement.GetProperty("color").GetString() ?? string.Empty;
                    var link = itemElement.GetProperty("inspectlink").GetString() ?? string.Empty;

                    items.Add(new Item(name, price, image, color, link));
                }
            }


            var inventory = new Inventory($"Inventory_{playerId}", playerId, "cs2")
            {
                Items = items
            };

            await _repository.Add(inventory, ct);
            return inventory;
        }

        public async Task<IEnumerable<Item>?> GetItemsAsync(int inventoryId, CancellationToken ct = default)
            => await _repository.GetItems(inventoryId, ct);
    }
}
