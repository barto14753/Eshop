using Eshop.Domain.Products;
using Refit;

namespace Eshop.Domain.Orders
{
    public interface IProductsApi
    {
        [Get("/products")]
        Task<List<Product>> GetAllProductsAsync();
    }
}
