using Microsoft.AspNetCore.Mvc;

namespace StockApp.API.Controllers
{
    public interface IProductsController
    {
        IActionResult CalculateDiscount(decimal price, decimal discountPercentage);
    }
}