using Eshop.Domain.CheckoutCart;
using Eshop.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Eshop.Infrastructure.Repositories
{
    internal class CheckoutCartRepository : ICheckoutCartRepository
    {
        private readonly CartsContext _context;
        private readonly IEntityTracker _entityTracker;

        public CheckoutCartRepository(CartsContext context, IEntityTracker entityTracker)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entityTracker = entityTracker ?? throw new ArgumentNullException(nameof(entityTracker));
        }

        public void Create(Cart cart)
        {
            _context.Carts.InsertOne(cart);
            _entityTracker.TrackEntity(cart);
        }

        public async Task<Cart> GetByIdAsync(Guid id)
        {
            var Cart = await _context.Carts.Find(c => c.Id == id).FirstAsync();

            if(Cart == null)
            {
                throw new CartNotExistsException(id);
            }

            _entityTracker.TrackEntity(Cart);

            return Cart;
        }

        public async void AddProduct(Guid cartId, CartProduct product)
        {
            var filter = Builders<Cart>.Filter.Eq(c => c.Id, cartId);
            var update = Builders<Cart>.Update.Push(c => c.Products, product);

            await _context.Carts.UpdateOneAsync(filter, update);
        }

        public async void DeleteProduct(Guid cartId, Guid productId)
        {
            var filter = Builders<Cart>.Filter.And(
                Builders<Cart>.Filter.Eq(c => c.Id, cartId),
                Builders<Cart>.Filter.ElemMatch(c => c.Products, p => p.Id == productId)
            );

            var update = Builders<Cart>.Update.PullFilter(c => c.Products, p => p.Id == productId);

            var updateResult = await _context.Carts.UpdateOneAsync(filter, update);

            if (updateResult.MatchedCount == 0)
            {
                throw new CartAndProductNotExistsException(cartId, productId);
            }

        }
    }
}
