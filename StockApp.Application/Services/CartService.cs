using StockApp.Application.Interfaces;
using StockApp.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApp.Application.Services
{
    public class CartService : ICartService
    {
        private readonly List<CartItem> _cartItems = new List<CartItem>();

        public async Task AddToCartAsync(CartItem cartItem)
        {
            var existingItem = _cartItems.FirstOrDefault(x => x.ProductId == cartItem.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += cartItem.Quantity;
            }
            else
            {
                _cartItems.Add(cartItem);
            }
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsAsync()
        {
            return await Task.FromResult(_cartItems);
        }

        public async Task RemoveFromCartAsync(int productId)
        {
            var item = _cartItems.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                _cartItems.Remove(item);
            }
            await Task.CompletedTask;
        }
    }
}