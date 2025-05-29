using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetAll(CancellationToken cts = default);
        Task<Inventory?> GetByPlayerId(string playerId, CancellationToken cts = default);
        Task Add(Inventory inventory, CancellationToken cts = default);
        Task<IEnumerable<Item>?> GetItems(int inventoryId, CancellationToken cts = default);
    }
}
