using Refit;
using SampleEcommerce.Mobile.Models.Cart;
using System.Threading.Tasks;

namespace SampleEcommerce.Mobile.Services.Cart
{
    public interface ICartApi
    {
        [Get("/api/v1/cart/{userId}")]
        Task<CustomerCart> GetCartAsync(string userId);

        [Post("/api/v1/cart/update")]
        Task<bool> UpdateCartAsync(CustomerCart customerCart);

        [Post("/api/v1/cart/checkout")]
        Task<bool> CheckoutCartAsync(CartCheckout cartCheckout);

        [Post("/api/v1/cart/clearcart")]
        Task<bool> ClearCartAsync(string userId);

    }
}
