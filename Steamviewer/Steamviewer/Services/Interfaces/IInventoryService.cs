using Steamviewer.Entities.DTOs;

namespace Steamviewer.Services.Interfaces
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> GetAllAsync(CancellationToken ct = default);
        Task<Inventory?> CreateInventoryAsync(string playerId, CancellationToken ct = default);
        Task<IEnumerable<Item>?> GetItemsAsync(int inventoryId, CancellationToken ct = default);
    }
}
