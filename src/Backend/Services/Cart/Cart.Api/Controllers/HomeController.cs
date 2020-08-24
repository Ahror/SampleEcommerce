using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.Controllers
{
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
