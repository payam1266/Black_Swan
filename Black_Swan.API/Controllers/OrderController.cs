using Black_Swan_Application.DTOs.City;
using Black_Swan_Application.DTOs.Order;
using Black_Swan_Application.Features.Brands.Requests.Commands;
using Black_Swan_Application.Features.Orders.Requests.Commands;
using Black_Swan_Application.Features.Orders.Requests.Queries;
using Black_Swan_Application.Responses;
using Black_Swan_Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Black_Swan.API.Controllers
{
    [Route("api/Order")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<OrderController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<OrderDto>>> Get()
        {
            var orders = await _mediator.Send(new GetOrderListRequest());
            return Ok(orders);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id:int}", Name = "GetOrderDto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDto>> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var order = await _mediator.Send(new GetOrderRequest { id = id });
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST api/<OrderController>
        [HttpPost(Name = "CreateOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] OrderDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest(orderDto);
            }
            if (orderDto.id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var command = new CreateOrderCommand { OrderDto = orderDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id:int}", Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Put(int id, [FromBody] OrderDto orderDto)
        {
            if (orderDto == null || orderDto.id != id)
            {
                return BadRequest();
            }
            var command = new UpdateOrderCommand { OrderDto = orderDto };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id:int}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var command = new DeleteOrderCommand { id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
