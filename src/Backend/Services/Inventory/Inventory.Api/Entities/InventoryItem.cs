using System;

namespace Inventory.Api.Entities
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int StockQty { get; set; }
        public int ReorderQty { get; set; }
        public int PriorityStatus { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
