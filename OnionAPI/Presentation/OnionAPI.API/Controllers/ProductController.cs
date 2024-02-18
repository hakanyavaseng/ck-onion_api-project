using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionAPI.Application.Features.Products.Commands.CreateProduct;
using OnionAPI.Application.Features.Products.Commands.DeleteProduct;
using OnionAPI.Application.Features.Products.Commands.UpdateProduct;
using OnionAPI.Application.Features.Products.Queries.GetAllProducts;

namespace OnionAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _mediator.Send(new GetAllProductsQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {
            CreateProductCommandResponse response =  await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }


    }
}
