using Catalog.Api.Entities;
using Catalog.Api.Models;
using Catalog.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            this.catalogService = catalogService;
        }

        [HttpGet]
        [Route("items")]
        [ProducesResponseType(typeof(IEnumerable<CatalogItem>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ItemsAsync([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0, string ids = null)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = await catalogService.GetCatalogItemsByIds(ids);

                if (!items.Any())
                {
                    return BadRequest("ids value invalid. Must be comma-separated list of numbers");
                }

                return Ok(items);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("items/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CatalogItem), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CatalogItem>> ItemByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var item = await catalogService.GetCatalogItemById(id);

            if (item != null)
            {
                return item;
            }

            return NotFound();
        }

        [HttpGet]
        [Route("items/getbyname/{name}")]
        public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByName(string name)
        {
            return await catalogService.GetCatalogItemsByName(name);
        }

        [HttpGet]
        [Route("items/type/{catalogTypeId}/brand/{catalogBrandId}")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<CatalogItem>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<CatalogItem>> GetCatalogItemsBy(int catalogTypeId, int? catalogBrandId)
        {
            return await catalogService.GetCatalogItemsBy(catalogTypeId, catalogBrandId);
        }

        [HttpGet]
        [Route("catalogtypes")]
        [ProducesResponseType(typeof(IEnumerable<CatalogType>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<CatalogType>> CatalogTypesAsync()
        {
            return await catalogService.GetCatalogTypes();
        }

        [HttpGet]
        [Route("catalogbrands")]
        [ProducesResponseType(typeof(IEnumerable<CatalogBrand>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<CatalogBrand>> CatalogBrandsAsync()
        {
            return await catalogService.GetCatalogBrands();
        }

        [Route("items")]
        [HttpPut]
        public async Task<bool> UpdateCatalogItemAsync([FromBody] CatalogItem catalogToUpdate)
        {
            return await catalogService.UpdateCatalogItemAsync(catalogToUpdate);
        }

        [Route("items")]
        [HttpPost]
        public async Task<bool> CreateCatalogItemAsync([FromBody] CatalogItem catalogItem)
        {
            return await catalogService.CreateCatalogItemAsync(catalogItem);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<bool> DeleteProductAsync(int id)
        {
            return await catalogService.DeleteCatalogItemAsync(id);
        }
    }
}
