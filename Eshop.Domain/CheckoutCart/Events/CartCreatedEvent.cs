using Eshop.Domain.SeedWork;

namespace Eshop.Domain.CheckoutCart.Events
{
    public class CartCreatedEvent : DomainEventBase
    {

        public Guid CartId { get; }

        public Guid CustomerId { get; }

        public CartCreatedEvent(Guid cartId, Guid customerId)
        {
            CartId = cartId;
            CustomerId = customerId;
        }
    }
}
