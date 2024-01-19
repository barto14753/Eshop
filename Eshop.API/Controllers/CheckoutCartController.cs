using Eshop.Application.Cusomters.Queries;
using Eshop.Application.Customers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Eshop.API.Controllers
{
    [Route("api/v1/cart")]
    [ApiController]
    public class CheckoutCartController : Controller
    {
        private readonly IMediator _mediator;

        public CheckoutCartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets checkout cart
        /// </summary>
        /// <param name="cartId">Cart ID.</param>
        [Route("{cartId}")]
        [HttpGet]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> GetCheckoutCart(
            [FromRoute] Guid cartId)
        {
            var response = await _mediator.Send(new GetCheckoutCartQuery(cartId));
            return Created(string.Empty, response);
        }


        /// <summary>
        /// Create new cart.
        /// </summary>
        /// <param name="request">List of products.</param>
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateCheckoutCart(
            [FromBody] CheckoutCartRequest request)
        {
            var response = await _mediator.Send(new CreateCheckoutCartCommand(request.CheckoutCart));
            return Created(string.Empty, response);
        }


        /// <summary>
        /// Add product
        /// </summary>
        /// <param name="cartId">cartId</param>
        /// <param name="request">product</param>
        [Route("{cartId}")]
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddProduct(
            [FromRoute] Guid cartId,
            [FromBody] CartProductRequest request)
        {
            var response = await _mediator.Send(new AddCartProductCommand(cartId, request.Product));
            return Created(string.Empty, response);
        }


        /// <summary>
        /// Remove product
        /// </summary>
        /// <param name="cartId">cartId</param>
        /// <param name="productId">Product to remove</param>
        [Route("{cartId}/{productId}")]
        [HttpDelete]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> DeleteCartProduct(
            [FromRoute] Guid cartId,
            [FromRoute] Guid productId)
        {
            var response = await _mediator.Send(new DeleteCartProductCommand(cartId, productId));
            return Created(string.Empty, response);
        }
    }
}
