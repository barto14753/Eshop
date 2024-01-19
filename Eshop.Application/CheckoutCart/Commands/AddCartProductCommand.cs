using Eshop.Application.Configuration.Commands;
using Eshop.Application.Shared;

namespace Eshop.Application.Customers.Commands
{
    public class AddCartProductCommand : CommandBase<Guid>
    {
        public Guid CartId { get; }
        public ProductDto Product { get; }


        public AddCartProductCommand(
            Guid cartId,
            ProductDto product)
        {
            CartId = cartId;
            Product = product;
        }
    }
}
