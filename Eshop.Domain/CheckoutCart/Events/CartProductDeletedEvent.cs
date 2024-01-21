using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Customers.Events
{
    public class CartProductDeletedEvent : DomainEventBase
    {

        public Guid CartId { get; }
        public Guid ProductId { get; }

        public CartProductDeletedEvent(Guid cartId, Guid productId)
        {
            CartId = cartId;
            ProductId = productId;
        }
    }
}
