using Eshop.Application.Configuration.Queries;
using Eshop.Application.Shared;

namespace Eshop.Application.Cusomters.Queries
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
