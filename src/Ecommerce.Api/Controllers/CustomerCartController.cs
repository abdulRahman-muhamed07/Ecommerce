using Ecommerce.Application.Features.Catalog.Cart.Queries.GetCart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CustomerCartController : ControllerBase
{
    private readonly GetCartHandler _getCartHandler;

    public CustomerCartController(GetCartHandler getCartHandler)
    {
        _getCartHandler = getCartHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetCart(
        CancellationToken cancellationToken)
    {
        var query = new GetCartQuery();

        var result = await _getCartHandler.HandleAsync(
            query,
            cancellationToken);

        if (result is null)
            return NotFound();

        return Ok(result);
    }
}