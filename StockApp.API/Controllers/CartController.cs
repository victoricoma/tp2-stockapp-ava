using Microsoft.AspNetCore.Mvc;
using StockApp.Application.Interfaces;
using StockApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] CartItem cartItem)
        {
            await _cartService.AddToCartAsync(cartItem);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems()
        {
            var cartItems = await _cartService.GetCartItemsAsync();
            return Ok(cartItems);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            await _cartService.RemoveFromCartAsync(productId);
            return NoContent();
        }
    }
}
