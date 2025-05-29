using DAL.Context;
using DAL.Mapping;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class InventoryRepository(AppDbContext context) : IInventoryRepository
    {
        private readonly AppDbContext _context = context;
        
        public async Task<IEnumerable<Inventory>> GetAll(CancellationToken cts = default)
        {
            var dbInventories = await _context.Inventories.Include(i => i.Items).ToListAsync(cts);
            return dbInventories.Select(Mapper.ToDomain).ToList();
        }
        public async Task<Inventory?> GetByPlayerId(string playerId, CancellationToken cts = default)
        {
            var dbInventory = await _context.Inventories.Include(i => i.Items)
                .FirstOrDefaultAsync(i => i.PlayerId == playerId, cts);

            return dbInventory == null ? null : Mapper.ToDomain(dbInventory);
        }

        public async Task Add(Inventory inventory, CancellationToken cts = default)
        {
            await _context.Inventories.AddAsync(Mapper.ToDb(inventory), cts);
            await _context.SaveChangesAsync(cts);
        }

        public async Task<IEnumerable<Item>?> GetItems(int inventoryId, CancellationToken cts = default)
        {
            var inventory = await _context.Inventories.Include(i => i.Items)
                .FirstOrDefaultAsync(i => i.Id == inventoryId, cts);

            return inventory?.Items.Select(Mapper.ToDomain);
        }
    }
}
