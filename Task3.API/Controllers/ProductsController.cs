using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task3.Application.DTOs;
using Task3.Application.Features.Products.Command.CreateProduct;
using Task3.Application.Features.Products.Query.GetProductById;
using Task3.Application.Features.Products.Query.GetProducts;

namespace Task3.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductResponseDto>>> GetAll(
            CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetProductsQuery(), cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductResponseDto>> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetProductByIdQuery(id), cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponseDto>> Create([FromBody] CreateProductDto dto, CancellationToken cancellationToken)
        {
            var command = new CreateProductCommand(dto.Name,dto.Price);

            var result = await _sender.Send(command, cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
    }
}
