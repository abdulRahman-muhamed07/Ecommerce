using Ecommerce.Application.Features.Catalog.Products.Queries.GetProductById;
using Ecommerce.Application.Features.Catalog.Products.Queries.GetProducts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using FluentValidation;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerProductsController : ControllerBase
    {

        private readonly IValidator<GetProductsQuery> _getProductsValidator;
        private readonly GetProductsHandler _handler;
        private readonly GetProductsHandler _getProductsHandler;

        private readonly GetProductByIdHandler _getProductByIdHandler;

        public CustomerProductsController(GetProductsHandler handler, GetProductByIdHandler getProductByIdHandler, 
            GetProductsHandler getProductsHandler, IValidator<GetProductsQuery> getProductsValidator)
        {       
            
            _getProductsHandler = getProductsHandler;
            _getProductsValidator = getProductsValidator;

            _handler = handler;
            _getProductByIdHandler = getProductByIdHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] GetProductsQuery query,CancellationToken cancellationToken)


        {
            var validationResult = await _getProductsValidator.ValidateAsync(
                query,
                cancellationToken);

            if (!validationResult.IsValid)
            {
                return ValidationProblem(
                    validationResult.ToDictionary());
            }

            var result = await _getProductsHandler.HandleAsync(
                query,
                cancellationToken);

            return Ok(result);
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
