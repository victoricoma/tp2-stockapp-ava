using StockApp.Application.Interfaces;
using StockApp.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApp.Application.Services
{
    public class CartService : ICartService
    {
        private readonly List<CartItem> _cartItems;

        public CartService()
        {
            _cartItems = new List<CartItem>();
        }

        public Task AddToCartAsync(CartItem cartItem)
        {
            _cartItems.Add(cartItem);
            return Task.CompletedTask;
        }

        public Task RemoveFromCartAsync(int productId)
        {
            var itemToRemove = _cartItems.FirstOrDefault(item => item.ProductId == productId);
            if (itemToRemove != null)
                _cartItems.Remove(itemToRemove);
            return Task.CompletedTask;
        }

        public Task<List<CartItem>> GetCartItemsAsync()
        {
            return Task.FromResult(_cartItems);
        }
    }
}
