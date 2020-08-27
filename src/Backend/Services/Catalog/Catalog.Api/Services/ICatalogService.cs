using Catalog.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Services
{
    public interface ICatalogService
    {
        Task<IEnumerable<CatalogItem>> GetCatalogItems();
        Task<IEnumerable<CatalogItem>> GetCatalogItemsByIds(string ids);
        Task<CatalogItem> GetCatalogItemById(int id);
        Task<IEnumerable<CatalogItem>> GetCatalogItemsByName(string name);
        Task<IEnumerable<CatalogItem>> GetCatalogItemsBy(int catalogTypeId, int? catalogBrandId);
        Task<IEnumerable<CatalogType>> GetCatalogTypes();
        Task<IEnumerable<CatalogBrand>> GetCatalogBrands();
        Task<bool> UpdateCatalogItemAsync(CatalogItem catalogItem);
        Task<bool> CreateCatalogItemAsync(CatalogItem catalogItem);
        Task<bool> DeleteCatalogItemAsync(int id);


    }
}
