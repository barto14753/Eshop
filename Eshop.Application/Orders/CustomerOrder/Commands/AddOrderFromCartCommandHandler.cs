using AutoMapper;
using Eshop.Application.Configuration.Commands;
using Eshop.Domain.CheckoutCart;
using Eshop.Domain.Orders;
using Eshop.Domain.SeedWork;

namespace Eshop.Application.Orders.CustomerOrder.Commands
{
    public class AddOrderFromCartCommandHandler : ICommandHandler<AddOrderFromCartCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICheckoutCartRepository _checkoutCartRepository;
        private readonly IProductPriceDataApi _productPriceDataApi;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddOrderFromCartCommandHandler(
            IOrderRepository orderRepository,
            ICheckoutCartRepository checkoutCartRepository,
            IProductPriceDataApi productPriceDataApi, 
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _checkoutCartRepository = checkoutCartRepository ?? throw new ArgumentNullException(nameof(checkoutCartRepository));
            _productPriceDataApi = productPriceDataApi ?? throw new ArgumentNullException(nameof(productPriceDataApi));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Guid> Handle(AddOrderFromCartCommand request, CancellationToken cancellationToken)
        {         
            var productsData = await _productPriceDataApi.Get();
            var cart = await _checkoutCartRepository.GetByIdAsync(request.CartId);

            var order = Order.Create(
                cart,
                productsData);

            _orderRepository.Add(order);

            await _unitOfWork.CommitAsync(cancellationToken);

            return order.Id;
        }
    }
}
