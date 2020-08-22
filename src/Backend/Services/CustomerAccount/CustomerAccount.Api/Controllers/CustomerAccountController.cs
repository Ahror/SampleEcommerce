using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerAccount.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerAccountController : ControllerBase
    {
        private readonly ILogger<CustomerAccountController> _logger;

        public CustomerAccountController(ILogger<CustomerAccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Customer account controller");
        }
    }
}
