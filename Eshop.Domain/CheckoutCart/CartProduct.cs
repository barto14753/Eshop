using Eshop.Domain.SeedWork;

namespace Eshop.Domain.CheckoutCart
{
    public class CartProduct : ValueObject
    {
        public Guid Id { get; private set; }

        public int Quantity { get; private set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalCost
        {
            get { return Quantity * UnitPrice; }
        }

        private CartProduct()
        {

        }

        private CartProduct(Guid productId, int quantity, decimal unitPrice)
        {
            Id = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public static CartProduct Create(Guid productId, int quantity, decimal unitPrice)
        {
            return new CartProduct(productId, quantity, unitPrice);
        }

    }
}
