namespace Eshop.Application.Shared
{
    public class CheckoutCartDto
    {
        public Guid Id { get; }

        public List<ProductDto> Products { get; }

        private CheckoutCartDto()
        {
            Products = new List<ProductDto>();
        }

        public CheckoutCartDto(Guid id, List<ProductDto> products)
        {
            Id = id;
            Products = products ?? throw new ArgumentNullException(nameof(products));
        }
    }
}
