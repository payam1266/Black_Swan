using Black_Swan_Application.DTOs.Brand;
using Black_Swan_Application.DTOs.CardItem;
using Black_Swan_Application.Features.CardItems.Requests.Commands;
using Black_Swan_Application.Features.CardItems.Requests.Queries;
using Black_Swan_Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Black_Swan.API.Controllers
{
    [Route("api/CardItem")]
    [ApiController]
    [Authorize]
    public class CardItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CardItemController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<CardItemController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CardItemDto>>> Get()
        {
            var cardItems = await _mediator.Send(new GetCartItemsListRequest());
            
            return Ok(cardItems);
        }

        // GET api/<CardItemController>/5
        [HttpGet("{id:int}", Name = "GetCardItem")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CardItemDto>> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var cardItem = await _mediator.Send(new GetCardItemRequest { id = id });
            if (cardItem == null)
            {
                return NotFound();
            }
            return Ok(cardItem);
        }

        // POST api/<CardItemController>
        [HttpPost]
      
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CardItemDto cardItemDto)
        {
            if (cardItemDto == null)
            {
                return BadRequest();
            }
            if (cardItemDto.id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var command = new CreateCartItemCommand { CardItemDto = cardItemDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CardItemController>/5
        [HttpPut("{id:int}",Name = "UpdateCardItem")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Put(int id, [FromBody] CardItemDto cardItemDto)
        {
            if (cardItemDto == null || cardItemDto.id != id)
            {
                return BadRequest();
            }
            var command = new UpdateCardItemCommand { CardItemDto = cardItemDto };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CardItemController>/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var command = new DeleteCardItemCommand { id=id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

