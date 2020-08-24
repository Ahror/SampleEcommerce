using SampleEcommerce.Mobile.Models.Cart;
using System.Threading.Tasks;

namespace SampleEcommerce.Mobile.Services.Cart
{
    public interface ICartService
    {
        Task<CustomerCart> GetCartAsync(string userId);
        Task<bool> UpdateCartAsync(CustomerCart customerCart);
        Task<bool> CheckoutAsync(CartCheckout CartCheckout);
        Task<bool> ClearCartAsync(string userId);
    }
}
