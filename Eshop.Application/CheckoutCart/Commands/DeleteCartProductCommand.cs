using Eshop.Application.Configuration.Commands;
using Eshop.Application.Shared;

namespace Eshop.Application.Customers.Commands
{
    public class DeleteCartProductCommand : CommandBase<Guid>
    {
        public Guid CartId{ get; }
        public Guid ProductId { get; }


        public DeleteCartProductCommand(
            Guid cartId,
            Guid productId)
        {
            CartId = cartId;
            ProductId = productId;
        }
    }
}
