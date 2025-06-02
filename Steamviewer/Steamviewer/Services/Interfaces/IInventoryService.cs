using Steamviewer.Entities.DTOs;

namespace Steamviewer.Services.Interfaces
{
    public interface IInventoryService : IService<InventoryDto>
    {
        Task<InventoryDto?> AddInventoryAsync(string playerId, CancellationToken ct = default);
        Task<IEnumerable<ItemDto>> GetInventoryItemsAsync(int inventoryId, CancellationToken ct = default);
        Task<InventoryDto?> GetByPlayerIdAsync(string playerId, CancellationToken ct = default);
        Task DeleteAsync(int id, CancellationToken ct = default);
    }
}
