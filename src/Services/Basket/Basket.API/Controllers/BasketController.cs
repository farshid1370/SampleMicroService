using Basket.API.Application.Features.Basket.Commands.UpdateBasket;
using Basket.API.Application.Features.Basket.Queries.GetCustomerBasket;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get basket by customer id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasketById(string id)
        {
            var basket = await _mediator.Send(new GetCustomerBasketQuery { CustomerId = id });

            return Ok(basket);
        }

        /// <summary>
        /// Update basket
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateBasket([FromBody] UpdateBasketCommand command)
        {

            await _mediator.Send(command);
            return CreatedAtAction(nameof(GetBasketById), new { id = command.BuyerId }, null);


        }
    }
}
