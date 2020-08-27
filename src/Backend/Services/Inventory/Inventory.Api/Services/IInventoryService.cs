using Inventory.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Api.Services
{
    public interface IInventoryService
    {
        Task<IEnumerable<InventoryItem>> GetInventories();
        Task<IEnumerable<InventoryItem>> GetInventoryByName(string name);
        Task<InventoryItem> GetInventory(int id);
        Task<bool> UpdateInventoryItemAsync(InventoryItem inventory);
        Task<bool> CreateInventoryItemAsync(InventoryItem inventory);
        Task<bool> DeleteInventoryItemAsync(int id);
    }
}
