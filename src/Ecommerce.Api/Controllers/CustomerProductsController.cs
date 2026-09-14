using Ecommerce.Application.Features.Catalog.Products.Queries.GetProductById;
using Ecommerce.Application.Features.Catalog.Products.Queries.GetProducts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerProductsController : ControllerBase
    {


        private readonly GetProductsHandler _handler;

        private readonly GetProductByIdHandler _getProductByIdHandler;

        public CustomerProductsController(GetProductsHandler handler, GetProductByIdHandler getProductByIdHandler)
        {
            _handler = handler;
            _getProductByIdHandler = getProductByIdHandler;
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)

        { 
            var query = new GetProductByIdQuery(id);

            var result = await _getProductByIdHandler.HandleAsync(
                query,
                cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(result);
        }








    }
}
