using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Products
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}
