using Cart.Api.Abstractions.Repositories;
using Cart.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cart.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository repository;
        private readonly ILogger<CartController> logger;
        public CartController(
            ICartRepository repository,
            ILogger<CartController> logger)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerCart>> GetCartByIdAsync(string id)
        {
            var basket = await repository.GetCartAsync(id);

            return Ok(basket ?? new CustomerCart(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerCart>> UpdateBasketAsync([FromBody] CustomerCart value)
        {
            return Ok(await repository.UpdateCartAsync(value));
        }

        [Route("checkout")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CheckoutAsync([FromBody] CartCheckout basketCheckout)
        {
            //Willl be implement soon
            return Accepted();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task DeleteCartByIdAsync(string id)
        {
            await repository.DeleteCartAsync(id);
        }
    }
}
