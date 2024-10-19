using MediatR;
using Microsoft.AspNetCore.Mvc;

using App.Infastructure.Commands;
using App.Infastructure.Queries.Products;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("")]
        //[ValidationModel]
        public async Task<IActionResult> CreateProductAsync([FromBody]CreateProduct.Request request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetProductsAsync([FromBody]GetProducts.Query request)
        {
            request =  request ?? new GetProducts.Query();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromUri]Guid id, [FromBody]GetProductById.Query request)
        {
            request = request ?? new GetProductById.Query();
            request.Id = id;
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
