using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockApp.Infra.Data.Context;
using StockApp.Application.DTOs;

namespace StockApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StockController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("dashboard-stock")]
        public async Task<IActionResult> GetDashBoardStockData()
        {
            var dashboardData = new DashboardStockDTO
            {
                TotalProducts = await _context.Products.CountAsync(),
                TotalStockValue = await _context.Products.SumAsync(p => p.Stock * p.Price),
                LowStockProducts = await _context.Products.Where(p => p.Stock < 10)
                .Select(p => new ProductStockDTO
                {
                    ProductName = p.Name,
                    Stock = p.Stock,
                }).ToListAsync()
            };
            return Ok(dashboardData);
        }
    }
}
