using Catalog.Api.Data;
using Catalog.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly CatalogContext catalogContext;
        public CatalogService(CatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }

        public async Task<CatalogItem> GetCatalogItemById(int id)
        {
            return await catalogContext.CatalogItems.SingleOrDefaultAsync(ci => ci.Id == id);
        }

        public async Task<IEnumerable<CatalogItem>> GetCatalogItems()
        {
            return await catalogContext.CatalogItems.ToListAsync();
        }

        public async Task<IEnumerable<CatalogItem>> GetCatalogItemsBy(int catalogTypeId, int? catalogBrandId)
        {
            List<CatalogItem> result = await catalogContext.CatalogItems.Where(c => c.CatalogTypeId == catalogTypeId).ToListAsync();

            if (catalogBrandId != null)
                result = result.Where(r => r.CatalogBrandId == catalogBrandId).ToList();

            return result;
        }

        public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByIds(string ids)
        {
            var numIds = ids.Split(',').Select(id => (Ok: int.TryParse(id, out int x), Value: x));

            if (!numIds.All(nid => nid.Ok))
            {
                return new List<CatalogItem>();
            }

            var idsToSelect = numIds
                .Select(id => id.Value);

            var items = await catalogContext.CatalogItems.Where(ci => idsToSelect.Contains(ci.Id)).ToListAsync();

            return items;
        }

        public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByName(string name)
        {
            return await catalogContext.CatalogItems.Where(ci => ci.Name == name).ToListAsync();
        }

        public async Task<IEnumerable<CatalogType>> GetCatalogTypes()
        {
            return await catalogContext.CatalogTypes.ToListAsync();
        }

        public async Task<IEnumerable<CatalogBrand>> GetCatalogBrands()
        {
            return await catalogContext.CatalogBrands.ToListAsync();
        }

        public async Task<bool> UpdateCatalogItemAsync(CatalogItem catalogItem)
        {
            catalogContext.Update(catalogItem);
            return await catalogContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> CreateCatalogItemAsync(CatalogItem catalogItem)
        {
            catalogContext.Add(catalogItem);
            return await catalogContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCatalogItemAsync(int id)
        {
            var catalog = catalogContext.CatalogItems.FirstOrDefault(c => c.Id == id);
            if (catalog == null) return false;

            catalogContext.CatalogItems.Remove(catalog);
            return await catalogContext.SaveChangesAsync() > 0;
        }
    }
}
