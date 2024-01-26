using Eshop.Domain.Orders;
using Eshop.Domain.Products;
using Eshop.Infrastructure.Api;
using Microsoft.Extensions.Configuration;
using Refit;

namespace Eshop.Infrastructure
{
    internal class ProductPriceDataApi : IProductPriceDataApi
    {
        private readonly string _productApi;
        public ProductPriceDataApi(ApiContext apiContext)
        {
            _productApi = apiContext._productApi;
        }

        public async Task<List<ProductPriceData>> Get()
        {
            var api = RestService.For<IProductsApi>(_productApi);

            var products = await api.GetAllProductsAsync();

            List<ProductPriceData> productPriceDatas = new List<ProductPriceData>();

            foreach (var product in products)
            {
                Guid productId = Guid.Parse(product.Id);
                int productPrice = product.Price;
                ProductPriceData productPriceData = new ProductPriceData(productId, productPrice);
                productPriceDatas.Add(productPriceData);
            }

            return await Task.FromResult(productPriceDatas);
        }
    }
}
