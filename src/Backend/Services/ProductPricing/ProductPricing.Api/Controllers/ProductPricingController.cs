using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProductPricing.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductPricingController : ControllerBase
    {
        private readonly ILogger<ProductPricingController> _logger;

        public ProductPricingController(ILogger<ProductPricingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("ProductPricing controller");
        }
    }
}
