using System.Collections.Generic;

namespace SampleEcommerce.Mobile.Models.Cart
{
    public class CustomerCart
    {
        public string BuyerId { get; set; }
        public List<CartItem> Items { get; set; }

    }
}
