using Black_Swan_Application.DTOs.Brand;
using Black_Swan_Application.DTOs.City;
using Black_Swan_Application.Features.Brands.Requests.Commands;
using Black_Swan_Application.Features.Brands.Requests.Queries;
using Black_Swan_Application.Responses;
using Black_Swan_Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Black_Swan.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/Brand")]
    [ApiController]
    [Authorize]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<BrandController>
        [HttpGet]
   
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<BrandDto>>> Get()
        {
            var brands = await _mediator.Send(new GetBrandListRequest());
            return Ok(brands);
        }

        // GET api/<BrandController>/5
        [HttpGet("{id:int}", Name = "GetBrand")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<BrandDto>> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var brand = await _mediator.Send(new GetBrandRequest { id = id });
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        // POST api/<BrandController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBrandDto brandDto)
        {
            if (brandDto == null)
            {
                return BadRequest();
            }
            if (brandDto.id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var command = new CreateBrandCommand { BrandDto = brandDto };
            var response = await _mediator.Send(command);
            if (response.success == true)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status409Conflict, response);
            }
            //return CreatedAtRoute("GetBrand", new {response.id},brandDto);
        }

        // PUT api/<BrandController>/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<BaseCommandResponse>> Put(int id, [FromBody] BrandDto brandDto)
        {
            if (brandDto == null || brandDto.id != id)
            {
                return BadRequest();
            }
            var command = new UpdateBrandCommand { BrandDto = brandDto };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var command = new DeleteBrandCommand { id = id };
            await _mediator.Send(command);
            return NoContent();

        }
    }
}
