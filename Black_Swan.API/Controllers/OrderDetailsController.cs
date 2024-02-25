using Black_Swan_Application.DTOs.Order;
using Black_Swan_Application.DTOs.OrderDetails;
using Black_Swan_Application.Features.OrderDetail.Requests.Commands;
using Black_Swan_Application.Features.OrderDetail.Requests.Queries;
using Black_Swan_Application.Responses;
using Black_Swan_Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Black_Swan.API.Controllers
{
    [Route("api/OrderDetails")]
    [ApiController]
    [Authorize]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<OrderDetailsController>
        [HttpGet(Name = "GetorderDetailsList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<OrderDetailsDto>>> Get()
        {
            var orderDetails = await _mediator.Send(new GetListOrderDetailsRequest());
            return Ok(orderDetails);
        }

        // GET api/<OrderDetailsController>/5
        [HttpGet("{id:int}",Name = "GetOrderDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDetailsDto>> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var orderDetail = await _mediator.Send(new GetOrderDetailsRequest { id = id });
            if (orderDetail == null)
            {
                return NotFound();
            }
            return Ok(orderDetail);
        }

        // POST api/<OrderDetailsController>
        [HttpPost(Name = "CreateOrderDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] OrderDetailsDto orderDetailsDto)
        {
            if (orderDetailsDto == null)
            {
                return BadRequest(orderDetailsDto);
            }
            if (orderDetailsDto.id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var command = new CreateOrderDetailsCommand { OrderDetailsDto = orderDetailsDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<OrderDetailsController>/5
        [HttpPut("{id:int}",Name = "UpdateOrderDetails")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Put(int id, [FromBody] OrderDetailsDto orderDetailsDto)
        {
            if (orderDetailsDto == null || orderDetailsDto.id != id)
            {
                return BadRequest();
            }
            var command = new UpdateOrderDetailsCommand { OrderDetailsDto = orderDetailsDto };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<OrderDetailsController>/5
        [HttpDelete("{id:int}",Name = "DeleteOrderDetails")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var command = new DeleteOrderDetailsCommand {id=id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
