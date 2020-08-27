using Inventory.Api.Data;
using Inventory.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Api.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly InventoryContext inventoryContext;
        public InventoryService(InventoryContext inventoryContext)
        {
            this.inventoryContext = inventoryContext;
        }
        public async Task<bool> CreateInventoryItemAsync(InventoryItem inventory)
        {
            inventoryContext.Add(inventory);
            return await inventoryContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteInventoryItemAsync(int id)
        {
            var inventory = inventoryContext.Inventories.FirstOrDefault(c => c.Id == id);
            if (inventory == null) return false;

            inventoryContext.Inventories.Remove(inventory);
            return await inventoryContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<InventoryItem>> GetInventories()
        {
            return await inventoryContext.Inventories.ToListAsync();
        }

        public async Task<InventoryItem> GetInventory(int id)
        {
            return await inventoryContext.Inventories.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<InventoryItem>> GetInventoryByName(string name)
        {
            return await inventoryContext.Inventories.Where(i => i.ItemName == name).ToListAsync();
        }

        public async Task<bool> UpdateInventoryItemAsync(InventoryItem inventory)
        {
            inventoryContext.Update(inventory);
            return await inventoryContext.SaveChangesAsync() > 1;
        }
    }
}
