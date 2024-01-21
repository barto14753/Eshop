using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Customers.Events
{
    public class CartProductAddedEvent : DomainEventBase
    {

        public Guid CartId { get; }
        public Guid ProductId { get; }

        public CartProductAddedEvent(Guid cartId, Guid productId)
        {
            CartId = cartId;
            ProductId = productId;
        }
    }
}
