using Eshop.Application.Shared;

namespace Eshop.API.Controllers
{
    public class CartProductRequest
    {
        public ProductDto Product { get; set; }

        public CartProductRequest(ProductDto product)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
        }
    }
}
