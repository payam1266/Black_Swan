using Black_Swan_Application.DTOs.City;
using Black_Swan_Application.Features.Cities.Requests.Commands;
using Black_Swan_Application.Features.Cities.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Black_Swan.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/City")]
    [ApiController]
    [Authorize]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<CityController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<CityDto>>> Get()
        {
            var cities = await _mediator.Send(new GetListCitiesRequest());
            if (cities == null)
            {
                return NotFound();
            }

            return Ok(cities);
        }

        // GET api/<CityController>/5
        [HttpGet("{id:int}",Name = "GetCity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CityDto>> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var city = await _mediator.Send(new GetCityRequest { id = id });
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        // POST api/<CityController>
        [HttpPost(Name ="CreateCity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody] CreateCityDto cityDto)
        {
            if (cityDto == null)
            {
                return BadRequest(cityDto);
            }
            if (cityDto.id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var command = new CreateCityCommand { CityDto = cityDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CityController>/5
        [HttpPut("{id:int}",Name ="UpdateCity")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Put(int id, [FromBody] CityDto cityDto)
        {
            if (cityDto == null || cityDto.id != id)
            {
                return BadRequest();
            }
            var command = new UpdateCityCommand { CityDto = cityDto };
            await _mediator.Send(command);
            return NoContent();

        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var command = new DeleteCityCommand { id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
