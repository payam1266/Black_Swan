using Black_Swan_Application.DTOs.Product;
using Black_Swan_Application.Features.Products.Requests.Commands;
using Black_Swan_Application.Features.Products.Requests.Queries;
using Black_Swan_Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Black_Swan.API.Controllers
{
    [Route("api/Product")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<ProductController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            var products = await _mediator.Send(new GetProductsListRequest());
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);

        }

        // GET api/<ProductController>/5
        [HttpGet("{id:int}", Name = "GetProductDto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var product = await _mediator.Send(new GetProductRequest { id = id });
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost(Name = "CreateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]


        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateProductDto createProductDto)
        {
            if (createProductDto == null)
            {
                return BadRequest();
            }
            if (createProductDto.id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var command = new CreateProductCommand { ProductDto = createProductDto };
            var response = await _mediator.Send(command);

            if (response.success == true)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status409Conflict, response);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id:int}", Name = "updateProductDto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]

        public async Task<ActionResult<BaseCommandResponse>> Put(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            if (updateProductDto == null || updateProductDto.id != id)
            {
                return BadRequest();
            }

            var command = new UpdateProductCommand { ProductDto = updateProductDto };
            var response = await _mediator.Send(command);
            if (response.success == true)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status409Conflict, response);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id:int}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var command = new DeleteProductCommand { Id = id };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
