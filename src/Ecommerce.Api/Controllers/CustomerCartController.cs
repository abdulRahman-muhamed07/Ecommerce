using Ecommerce.Application.Features.Catalog.Cart.Commands.AddToCart;
using Ecommerce.Application.Features.Catalog.Cart.Commands.AddToCart.UpdateCartItem;
using Ecommerce.Application.Features.Catalog.Cart.Commands.ClearCart;
using Ecommerce.Application.Features.Catalog.Cart.Commands.RemoveCartItem;
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

    private readonly RemoveCartItemHandler _removeCartItemHandler;
    private readonly ClearCartHandler _clearCartHandler;

    public CustomerCartController(GetCartHandler getCartHandler, 
        AddToCartHandler addToCartHandler, UpdateCartItemHandler updateCartItemHandler, 
        RemoveCartItemHandler removeCartItemHandler, ClearCartHandler clearCartHandler)
    {
        _getCartHandler = getCartHandler;
        _addToCartHandler = addToCartHandler;
        _updateCartItemHandler = updateCartItemHandler;
        _removeCartItemHandler = removeCartItemHandler;
        _clearCartHandler = clearCartHandler;
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




    [HttpDelete("items/{cartItemId:guid}")]
    public async Task<IActionResult> RemoveCartItem(
    Guid cartItemId,
    CancellationToken cancellationToken)
    {
        var command = new RemoveCartItemCommand(cartItemId);

        await _removeCartItemHandler.HandleAsync(
            command,
            cancellationToken);

        return NoContent();
    }




    [HttpDelete]
    public async Task<IActionResult> ClearCart(
    CancellationToken cancellationToken)
    {
        var command = new ClearCartCommand();

        await _clearCartHandler.HandleAsync(
            command,
            cancellationToken);

        return NoContent();
    }






}