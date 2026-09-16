using Ecommerce.Application.Features.Catalog.Products.Queries.GetProductById;
using Ecommerce.Application.Features.Catalog.Products.Queries.GetProductBySlug;
using Ecommerce.Application.Features.Catalog.Products.Queries.GetProducts;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerProductsController : ControllerBase
{
    private readonly GetProductsHandler _getProductsHandler;
    private readonly GetProductByIdHandler _getProductByIdHandler;
    private readonly IValidator<GetProductsQuery> _getProductsValidator;
    private readonly GetProductBySlugHandler _getProductBySlugHandler;
    public CustomerProductsController(
        GetProductsHandler getProductsHandler,
        GetProductByIdHandler getProductByIdHandler,
        IValidator<GetProductsQuery> getProductsValidator,
        GetProductBySlugHandler getProductBySlugHandler)
    {
        _getProductsHandler = getProductsHandler;
        _getProductByIdHandler = getProductByIdHandler;
        _getProductsValidator = getProductsValidator;
        _getProductBySlugHandler = getProductBySlugHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts(
        [FromQuery] GetProductsQuery query,
        CancellationToken cancellationToken)
    {
        var validationResult = await _getProductsValidator.ValidateAsync(
            query,
            cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .GroupBy(error => error.PropertyName)
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(error => error.ErrorMessage).ToArray());

            return BadRequest(new
            {
                message = "Validation failed.",
                errors
            });
        }

        var result = await _getProductsHandler.HandleAsync(
            query,
            cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var query = new GetProductByIdQuery(id);

        var result = await _getProductByIdHandler.HandleAsync(
            query,
            cancellationToken);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }



    [HttpGet("slug/{slug}")]
    public async Task<IActionResult> GetBySlug(
    string slug,
    CancellationToken cancellationToken)
    {
        var query = new GetProductBySlugQuery
        {
            Slug = slug
        };

        var result = await _getProductBySlugHandler.HandleAsync(
            query,
            cancellationToken);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}
