using Eshop.Application.Configuration.Commands;
using Eshop.Application.Shared;

namespace Eshop.Application.Orders.CustomerOrder.Commands
{
    public class AddOrderFromCartCommand : CommandBase<Guid>
    {
        public Guid CartId { get; }

        public AddOrderFromCartCommand(
            Guid cartId)
        {
            CartId = cartId;
        }
    }
}
