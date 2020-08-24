using ReactiveUI;
using System;

namespace SampleEcommerce.Mobile.Models.Cart
{
    public class CartItem : ReactiveObject
    {
        private int quantity;

        public string Id { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal OldUnitPrice { get; set; }

        public bool HasNewPrice
        {
            get
            {
                return OldUnitPrice != 0.0m;
            }
        }

        public int Quantity
        {
            get => quantity;
            set => this.RaiseAndSetIfChanged(ref quantity, value);
        }

        public string PictureUrl { get; set; }

        public decimal Total { get { return Quantity * UnitPrice; } }

        public override string ToString()
        {
            return String.Format("Product Id: {0}, Quantity: {1}", ProductId, Quantity);
        }
    }
}
