using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.Data
{
    public class DbInitializer
    {
        public static void Initialize(CatalogContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
