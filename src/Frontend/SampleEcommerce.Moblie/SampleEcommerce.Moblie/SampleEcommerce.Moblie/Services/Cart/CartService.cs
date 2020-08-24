using System.Threading.Tasks;
using SampleEcommerce.Mobile.Models.Cart;
using Refit;
using SampleEcommerce.Mobile.Helper;

namespace SampleEcommerce.Mobile.Services.Cart
{
    public class CartService : ICartService
    {
        protected readonly ICartApi cartApi;

        public CartService()
        {
            cartApi = RestService.For<ICartApi>(Constants.BaseUri);
        }

        public async Task<CustomerCart> GetCartAsync(string userId)
        {
            return await cartApi.GetCartAsync(userId);
        }

        public async Task<bool> UpdateCartAsync(CustomerCart customerCart)
        {
            return await cartApi.UpdateCartAsync(customerCart);
        }

        public async Task<bool> CheckoutAsync(CartCheckout cartCheckout)
        {
            return await cartApi.CheckoutCartAsync(cartCheckout);
        }

        public async Task<bool> ClearCartAsync(string userId)
        {
            return await cartApi.ClearCartAsync(userId);
        }
    }
}
