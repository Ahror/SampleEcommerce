using Inventory.Api.Entities;
using Inventory.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            this.inventoryService = inventoryService;
        }

        [HttpGet]
        [Route("items")]
        public async Task<IEnumerable<InventoryItem>> GetInventories()
        {
            return await inventoryService.GetInventories();
        }

        [HttpGet]
        [Route("items/byname/{name}")]
        public async Task<IEnumerable<InventoryItem>> GetInventoryByName(string name)
        {
            return await inventoryService.GetInventoryByName(name);
        }

        [HttpGet]
        [Route("items/{id}")]
        public async Task<InventoryItem> GetInventory(int id)
        {
            return await inventoryService.GetInventory(id);
        }

        [HttpPut]
        [Route("items")]
        public async Task<bool> GetInventory(InventoryItem inventory)
        {
            return await inventoryService.UpdateInventoryItemAsync(inventory);
        }

        [HttpPost]
        [Route("items")]
        public async Task<bool> CreateInventoryItem(InventoryItem inventory)
        {
            return await inventoryService.CreateInventoryItemAsync(inventory);
        }

        [HttpPost]
        [Route("items/{id}")]
        public async Task<bool> DeleteInventoryitem(int id)
        {
            return await inventoryService.DeleteInventoryItemAsync(id);
        }
    }
}
