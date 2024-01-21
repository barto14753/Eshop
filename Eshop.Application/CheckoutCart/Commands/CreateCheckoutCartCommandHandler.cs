using AutoMapper;
using Eshop.Application.Configuration.Commands;
using Eshop.Domain.CheckoutCart;
using Eshop.Domain.Orders;
using Eshop.Domain.SeedWork;

namespace Eshop.Application.CheckoutCart.Commands
{
    public class CreateCheckoutCartCommandHandler : ICommandHandler<CreateCheckoutCartCommand, Guid>
    {
        private readonly ICheckoutCartRepository _checkoutCartRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductPriceDataApi _productPriceDataApi;

        public CreateCheckoutCartCommandHandler(
            ICheckoutCartRepository checkoutCartRepository,
            IProductPriceDataApi productPriceDataApi,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _checkoutCartRepository = checkoutCartRepository ?? throw new ArgumentNullException(nameof(checkoutCartRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _productPriceDataApi = productPriceDataApi ?? throw new ArgumentNullException(nameof(productPriceDataApi));
        }

        public async Task<Guid> Handle(CreateCheckoutCartCommand request, CancellationToken cancellationToken)
        {
            var productsData = await _productPriceDataApi.Get();
            var checkoutCart = Cart.Create(
                request.CheckoutCart.CustomerId, 
                request.CheckoutCart.Products.Select(_mapper.Map<CartProduct>).ToList(), 
                productsData
            );

            _checkoutCartRepository.Create(checkoutCart);

            await _unitOfWork.CommitAsync(cancellationToken);

            return checkoutCart.Id;
        }
    }
}
