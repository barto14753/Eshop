using Eshop.Domain.CheckoutCart.Events;
using Eshop.Domain.Orders;
using Eshop.Domain.Products;
using Eshop.Domain.SeedWork;

namespace Eshop.Domain.CheckoutCart
{
    public class Cart : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }

        public Guid CustomerId { get; private set; }

        public List<CartProduct> Products { get; private set; }

        private Cart(Guid customerId, List<CartProduct> cartProducts)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            Products = cartProducts ?? throw new ArgumentNullException(nameof(cartProducts));

            AddDomainEvent(new CartCreatedEvent(Id, customerId));
        }

        public static Cart Create(
            Guid customerId,
            List<CartProduct> cartProducts,
            List<ProductPriceData> allProductPriceDatas)
        {
            List<CartProduct> _cartProducts = new();

            foreach (var cartProduct in cartProducts)
            {
                var productPriceData = allProductPriceDatas.First(x => x.ProductId == cartProduct.Id);

                var _cartProduct = CartProduct.Create(cartProduct.Id, cartProduct.Quantity, productPriceData.UnitPrice);

                _cartProducts.Add(_cartProduct);
            }

            return new Cart(customerId, _cartProducts);
        }
    }
}
