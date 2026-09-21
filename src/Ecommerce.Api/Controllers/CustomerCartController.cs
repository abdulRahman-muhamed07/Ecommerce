using Ecommerce.Application.Features.Catalog.Cart.Commands.AddToCart;
using Ecommerce.Application.Features.Catalog.Cart.Commands.AddToCart.UpdateCartItem;
using Ecommerce.Application.Features.Catalog.Cart.Commands.UpdateCartItem;
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
    private readonly AddToCartHandler _addToCartHandler;

    private readonly UpdateCartItemHandler _updateCartItemHandler;

    public CustomerCartController(GetCartHandler getCartHandler, AddToCartHandler addToCartHandler, UpdateCartItemHandler updateCartItemHandler)
    {
        _getCartHandler = getCartHandler;
        _addToCartHandler = addToCartHandler;
        _updateCartItemHandler = updateCartItemHandler;
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





    [HttpPost("items")]
    public async Task<IActionResult> AddToCart(
    AddToCartCommand command,
    CancellationToken cancellationToken)
    {
        await _addToCartHandler.HandleAsync(
            command,
            cancellationToken);

        return Ok();
    }





    [HttpPut("items/{cartItemId:guid}")]
    public async Task<IActionResult> UpdateCartItem(
        Guid cartItemId,
        UpdateCartItemCommand command,
        CancellationToken cancellationToken)
    {   
        var updatedCommand = new UpdateCartItemCommand
        {
            CartItemId = cartItemId,
            Quantity = command.Quantity
        };      

        await _updateCartItemHandler.HandleAsync(
            updatedCommand,
            cancellationToken);

        return NoContent();
    }
















}