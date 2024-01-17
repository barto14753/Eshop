using Eshop.Application.Shared;

namespace Eshop.API.Controllers
{
    public class CustomerRequest
    {
        public CustomerDto Customer { get; set; }

        public CustomerRequest(CustomerDto customer)
        {
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        }
    }
}
