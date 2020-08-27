using Inventory.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Api.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(
        DbContextOptions<InventoryContext> options)
        : base(options)
        {

        }

        public DbSet<InventoryItem> Inventories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=password");
        }
    }
}
