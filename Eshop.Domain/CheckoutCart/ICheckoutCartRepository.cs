namespace Eshop.Domain.CheckoutCart
{
    public interface ICheckoutCartRepository
    {
        Task<Cart> GetByIdAsync(Guid id);

        void Create(Cart cart);

        void AddProduct(Guid cartId, CartProduct product);

        void DeleteProduct(Guid cartId, Guid productId);
    }
}
