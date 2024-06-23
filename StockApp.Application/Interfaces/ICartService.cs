using StockApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockApp.Application.Interfaces
{
    public interface ICartService
    {
        Task AddToCartAsync(CartItem cartItem);
        Task<IEnumerable<CartItem>> GetCartItemsAsync();
        Task RemoveFromCartAsync(int productId);
    }
}