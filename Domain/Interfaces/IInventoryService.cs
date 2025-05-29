using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> GetAllAsync(CancellationToken ct = default);
        Task<Inventory?> GetByPlayerIdAsync(string playerId, CancellationToken ct = default);
        Task<Inventory?> CreateInventoryAsync(string playerId, CancellationToken ct = default);
        Task<IEnumerable<Item>?> GetItemsAsync(int inventoryId, CancellationToken ct = default);
    }
}
