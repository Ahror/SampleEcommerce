using Refit;
using SampleEcommerce.Mobile.Models.Catalog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleEcommerce.Mobile.Services.Catalog
{
    public interface ICatalogApi
    {
        [Get("/api/v1/catalog/items/type/{catalogType}/brand/{catalogBrand}")]
        Task<CatalogRoot> GetAsyncBy(int catalogType, int catalogBrand);

        [Get("/api/v1/catalog/items")]
        Task<CatalogRoot> GetCatalogAsync();

        [Get("/api/v1/catalog/catalogbrands")]
        Task<IEnumerable<CatalogBrand>> GetCatalogBrandAsync();

        [Get("/api/v1/catalog/catalogtypes")]
        Task<IEnumerable<CatalogType>> GetCatalogTypeAsync();
    }
}
