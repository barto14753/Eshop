using Eshop.Application.Orders.CustomerOrder.Commands;
using Eshop.Application.Customers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Eshop.Application.Cusomters.Queries;

namespace Eshop.API.Controllers
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Adds a new order for a specified customer.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        /// <param name="request">List of products.</param>
        [Route("{customerId}/orders")]
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddCustomerOrder(
            [FromRoute] Guid customerId,
            [FromBody] CustomerOrderRequest request)
        {
            var response = await _mediator.Send(new AddOrderCommand(customerId, request.Products));
            return Created(string.Empty, response);
        }

        /// <summary>
        /// Gets a specified customer.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        [Route("{customerId}")]
        [HttpGet]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> GetCustomer(
            [FromRoute] Guid customerId)
        {
            var customer = await _mediator.Send(new GetCustomerQuery(customerId));
            return Ok(customer);
        }


        /// <summary>
        /// Create new customer.
        /// </summary>
        /// <param name="request">name</param>
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateCustomer(
            [FromBody] CustomerRequest request)
        {
            var response = await _mediator.Send(new CreateCustomerCommand(request.Customer));
            return Created(string.Empty, response);
        }
    }
}
