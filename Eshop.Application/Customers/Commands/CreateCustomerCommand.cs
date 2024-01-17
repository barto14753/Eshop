using Eshop.Application.Configuration.Commands;
using Eshop.Application.Shared;

namespace Eshop.Application.Customers.Commands
{
    public class CreateCustomerCommand : CommandBase<Guid>
    {
        public CustomerDto Customer { get; }

        public CreateCustomerCommand(
            CustomerDto customer)
        {
            Customer = customer;
        }
    }
}
