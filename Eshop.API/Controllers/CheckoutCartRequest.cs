using Eshop.Application.Shared;

namespace Eshop.API.Controllers
{
    public class CheckoutCartRequest
    {
        public CheckoutCartDto CheckoutCart { get; set; }

        public CheckoutCartRequest(CheckoutCartDto checkoutCart)
        {
            CheckoutCart = checkoutCart ?? throw new ArgumentNullException(nameof(checkoutCart));
        }
    }
}
