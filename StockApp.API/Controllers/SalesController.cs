using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockApp.Infra.Data.Context;
using StockApp.Application.DTOs;

namespace StockApp.API.Controllers
{
    public class SalesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("dashboard-sales")]
        public async Task<IActionResult> GetDashBoardSalesData()
        {
            var dashBoardData = new DashBoardSalesDTO
            {
                TotalSales = await _context.Orders.SumAsync(o => o.Quantity * o.Price),
                TotalOrders = await _context.Orders.CountAsync(),
                TopSellingProducts = await _context.Products.OrderByDescending(p => p.Orders.Sum(o => o.Quantity)).Take(5).Select(p => new ProductSalesDTO
                {
                    ProductName = p.Name,
                    TotalSold = p.Orders.Sum(p => p.Quantity)
                }).ToListAsync()
            };
            return Ok(dashBoardData);
        }
    }
}
