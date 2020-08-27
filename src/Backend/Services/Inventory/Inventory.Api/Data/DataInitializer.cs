using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Api.Data
{
    public class DataInitializer
    {
        public static void Initialize(CatalogContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
