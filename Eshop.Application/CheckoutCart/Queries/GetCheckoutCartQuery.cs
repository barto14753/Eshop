using Eshop.Application.Configuration.Queries;
using Eshop.Application.Shared;

namespace Eshop.Application.CheckoutCart.Queries
{
    public class GetCheckoutCartQuery : IQuery<CheckoutCartDto>
    {
        public Guid CartId { get; }

        public GetCheckoutCartQuery(
            Guid cartId)
        {
            CartId = cartId;;
        }
    }
}
