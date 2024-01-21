public class CartAndProductNotExistsException : Exception
{
    public Guid CartId { get; }

    public Guid ProductId { get; }

    public CartAndProductNotExistsException(Guid cartId, Guid productId)
    {
        CartId = cartId;
        ProductId = productId;
    }
}