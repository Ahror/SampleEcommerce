using Refit;
using SampleEcommerce.Mobile.Helper;
using SampleEcommerce.Mobile.Models.Catalog;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SampleEcommerce.Mobile.Services.Catalog
{
    public class CatalogService : ICatalogService
    {
        protected readonly ICatalogApi catalogApi;

        public CatalogService()
        {
            catalogApi = RestService.For<ICatalogApi>(Constants.BaseUri);
        }

        public async Task<ObservableCollection<CatalogItem>> FilterAsync(int catalogBrandId, int catalogTypeId)
        {
            CatalogRoot catalog = await catalogApi.GetAsyncBy(catalogTypeId, catalogBrandId);

            if (catalog?.Data != null)
                return new ObservableCollection<CatalogItem>(catalog.Data);
            else
                return new ObservableCollection<CatalogItem>();
        }

        public async Task<ObservableCollection<CatalogItem>> GetCatalogAsync()
        {
            CatalogRoot catalog = await catalogApi.GetCatalogAsync();

            if (catalog?.Data != null)
            {
                return new ObservableCollection<CatalogItem>(catalog.Data);
            }
            else
                return new ObservableCollection<CatalogItem>();
        }

        public async Task<ObservableCollection<CatalogBrand>> GetCatalogBrandAsync()
        {
            IEnumerable<CatalogBrand> brands = await catalogApi.GetCatalogBrandAsync();

            if (brands != null)
                return new ObservableCollection<CatalogBrand>(brands);
            else
                return new ObservableCollection<CatalogBrand>();
        }

        public async Task<ObservableCollection<CatalogType>> GetCatalogTypeAsync()
        {

            IEnumerable<CatalogType> types = await catalogApi.GetCatalogTypeAsync();

            if (types != null)
                return new ObservableCollection<CatalogType>(types);
            else
                return new ObservableCollection<CatalogType>();
        }
    }
}
