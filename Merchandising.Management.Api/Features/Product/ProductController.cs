using MediatR;
using Merchandising.Management.Api.Features.Product.Commands;
using Merchandising.Management.Api.Features.Product.Queries;
using Merchandising.Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Merchandising.Management.Api.Features.Product
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

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ProductModel productModel)
        {
            productModel = await _mediator.Send(new PostProductCommand(productModel));
            return Ok(productModel);
        }

        [HttpGet("/byfilter")]
        public async Task<IActionResult> GetListByFilter([FromQuery] string queryFilter)
        {
            var productModel = await _mediator.Send(new GetProductListByFilterQuery(queryFilter));
            return Ok(productModel);
        }

        [HttpGet("/byrange")]
        public async Task<IActionResult> GetListByRange([FromQuery] int minRange, int maxRange)
        {
            var productList = await _mediator.Send(new GetProductListByRangeQuery(minRange, maxRange));
            return Ok(productList);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductModel productModel)
        {
            productModel = await _mediator.Send(new PutProductCommand(productModel));
            return Ok(productModel);
        }
    }
}
