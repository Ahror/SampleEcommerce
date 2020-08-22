using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Promotions.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly ILogger<PromotionsController> _logger;

        public PromotionsController(ILogger<PromotionsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Promotions controller");
        }
    }
}
