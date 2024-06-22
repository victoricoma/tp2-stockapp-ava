using Microsoft.EntityFrameworkCore;
using StockApp.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockApp.Domain.Entities;

namespace StockApp.Infra.Data.Repositories
{
    public class OrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>>GetByUserIdAsync(string userId)
        {
            return await _context.Orders.Include(o => o.Products).Where(order => order.UserId == userId).ToListAsync();
        }
    }
}
