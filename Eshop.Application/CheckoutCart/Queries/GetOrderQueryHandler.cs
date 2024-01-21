using AutoMapper;
using Eshop.Application.CheckoutCart.Queries;
using Eshop.Application.Configuration.Queries;
using Eshop.Application.Shared;
using Eshop.Domain.CheckoutCart;
using Eshop.Domain.Orders;

namespace Eshop.Application.Orders.CustomerOrder.Queries
{
    public class GetCheckoutCartQueryHandler : IQueryHandler<GetCheckoutCartQuery, CheckoutCartDto>
    {
        private readonly IMapper _mapper;
        private readonly ICheckoutCartRepository _checkoutCartRepository;

        public GetCheckoutCartQueryHandler(ICheckoutCartRepository checkoutCartRepository, IMapper mapper)
        {
            _checkoutCartRepository = checkoutCartRepository ?? throw new ArgumentNullException(nameof(checkoutCartRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CheckoutCartDto> Handle(GetCheckoutCartQuery request, CancellationToken cancellationToken)
        {
            var cart = await _checkoutCartRepository.GetByIdAsync(request.CartId);
            return _mapper.Map<CheckoutCartDto>(cart);
        }
    }
}
