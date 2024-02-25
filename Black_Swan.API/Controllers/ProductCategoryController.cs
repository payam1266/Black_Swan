using Black_Swan_Application.DTOs.Order;
using Black_Swan_Application.DTOs.OrderDetails;
using Black_Swan_Application.DTOs.ProductCategory;
using Black_Swan_Application.Features.Orders.Requests.Commands;
using Black_Swan_Application.Features.ProductCategories.Requests.Commands;
using Black_Swan_Application.Features.ProductCategories.Requests.Queries;
using Black_Swan_Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Black_Swan.API.Controllers
{
    [Route("api/ProductCategory")]
    [ApiController]
    [Authorize]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

       

        public ProductCategoryController(IMediator mediator)
        {
           _mediator = mediator;
        }
        // GET: api/<ProductCategoryController>
        [HttpGet(Name = "GetProductCategoriesList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductCategoryDto>>> Get()
        {
            var productCategories = await _mediator.Send(new GetProductCategoriesListRequest());
            return Ok(productCategories);
        }

        // GET api/<ProductCategoryController>/5
        [HttpGet("{id:int}",Name = "GetProductCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductCategoryDto>> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var productCategory = await _mediator.Send(new GetProductCategoryRequest { id = id });
            if (productCategory == null)
            {
                return NotFound();
            }
            return Ok(productCategory);
        }

        // POST api/<ProductCategoryController>
        [HttpPost(Name = "CreateProductCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody] ProductCategoryDto productCategoryDto)
        {
            if (productCategoryDto == null)
            {
                return BadRequest(productCategoryDto);
            }
            if (productCategoryDto.id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var command = new CreateProductCategoryCommand { ProductCategoryDto = productCategoryDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<ProductCategoryController>/5
        [HttpPut("{id:int}",Name = "UpdateProductCategory")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Put(int id, [FromBody] ProductCategoryDto productCategoryDto)
        {
            if (productCategoryDto == null || productCategoryDto.id != id)
            {
                return BadRequest();
            }
            var command = new UpdateProductCategoryCommand { ProductCategoryDto = productCategoryDto };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<ProductCategoryController>/5
        [HttpDelete("{id:int}",Name = "DeleteProductCategory")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var command = new DeleteProductCategoryCommand { id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
