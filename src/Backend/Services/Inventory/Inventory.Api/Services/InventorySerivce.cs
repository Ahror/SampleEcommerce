using Dapper;
using Inventory.Api.Entities;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Inventory.Api.Services
{
    public class InventoryService : IInventoryService
    {
        protected IDbConnection connection;
        public InventoryService(IDbConnection connection)
        {
            this.connection = connection;
        }
        public async Task<bool> CreateInventoryItemAsync(InventoryItem inventory)
        {
            var sql = "Insert into Inventories (ItemName,StockQty,ReorderQty,PriorityStatus,AddedDate) VALUES (@ItemName,@StockQty,@ReorderQty,@PriorityStatus,@AddedDate)";
            return await connection.ExecuteAsync(sql, inventory) > 0;
        }

        public async Task<bool> DeleteInventoryItemAsync(int id)
        {
            var sql = "Delete FROM Inventories WHERE Id = @Id";
            return await connection.ExecuteAsync(sql, new { Id = id }) > 0;
        }

        public async Task<IEnumerable<InventoryItem>> GetInventories()
        {
            var sql = "Select * FROM Inventories";
            return await connection.QueryAsync<InventoryItem>(sql);
        }

        public async Task<InventoryItem> GetInventory(int id)
        {
            var sql = "SELECT * FROM Inventories WHERE Id = @Id";
            return await connection.QuerySingleOrDefaultAsync<InventoryItem>(sql, new { Id = id });
        }

        public async Task<IEnumerable<InventoryItem>> GetInventoryByName(string name)
        {
            var sql = "SELECT * FROM Inventories WHERE ItemName = @ItemName";
            return await connection.QuerySingleOrDefaultAsync<IEnumerable<InventoryItem>>(sql, new { ItemName = name });
        }

        public async Task<bool> UpdateInventoryItemAsync(InventoryItem inventory)
        {
            var sql = "UPDATE Inventories SET ItemName = @ItemName, StockQty = @StockQty, ReorderQty = @ReorderQty, PriorityStatus = @PriorityStatus, AddedDate = @AddedDate  WHERE Id = @Id";
            return await connection.ExecuteAsync(sql, inventory) > 0;
        }
    }
}
