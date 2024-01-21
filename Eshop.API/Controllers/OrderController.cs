using Amazon.Runtime.Internal;
using Eshop.Application.Orders.CustomerOrder.Commands;
using Eshop.Application.Orders.CustomerOrder.Queries;
using Eshop.Application.Shared;
using Eshop.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Eshop.API.Controllers
{
    [Route("api/v1/orders")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieve order.
        /// </summary>
        /// <param name="orderId">Order ID.</param>
        [Route("{orderId}")]
        [HttpGet]
        [ProducesResponseType(typeof(OrderDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomerOrderDetails([FromRoute] Guid orderId)
        {
            var orderDetails = await _mediator.Send(new GetOrderQuery(orderId));
            return Ok(orderDetails);
        }

        /// <summary>
        /// Create order from checkout cart.
        /// </summary>
        /// <param name="cartId">CartId.</param>
        [Route("/cart/{cartId}")]
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddOrderFromCart(
            [FromRoute] Guid cartId)
        {
            var response = await _mediator.Send(new AddOrderFromCartCommand(cartId));
            return Created(string.Empty, response);
        }
    }
}
