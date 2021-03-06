﻿using System;
using System.Collections.Generic;

namespace Cart.Api.Models
{
    public class CustomerCart
    {
        public Guid Id { get; set; }
        public string BuyerId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public CustomerCart()
        {

        }

        public CustomerCart(string customerId)
        {
            BuyerId = customerId;
        }
    }
}
