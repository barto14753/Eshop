public class CartNotExistsException : Exception 
{ 
    public Guid Id { get; }

    public CartNotExistsException(Guid id)
    {
        Id = id;
    }
}