using AutoMapper;
using Eshop.Application.Configuration.Commands;
using Eshop.Domain.CheckoutCart;
using Eshop.Domain.SeedWork;

namespace Eshop.Application.CheckoutCart.Commands
{
    public class DeleteCartProductCommandHandler : ICommandHandler<DeleteCartProductCommand, Guid>
    {
        private readonly ICheckoutCartRepository _checkoutCartRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCartProductCommandHandler(
            ICheckoutCartRepository checkoutCartRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _checkoutCartRepository = checkoutCartRepository ?? throw new ArgumentNullException(nameof(checkoutCartRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Guid> Handle(DeleteCartProductCommand request, CancellationToken cancellationToken)
        {
            _checkoutCartRepository.DeleteProduct(request.CartId, request.ProductId);

            await _unitOfWork.CommitAsync(cancellationToken);

            return request.CartId;
        }
    }
}
