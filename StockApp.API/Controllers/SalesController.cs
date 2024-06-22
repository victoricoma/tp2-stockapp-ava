using Microsoft.AspNetCore.Mvc;
using StockApp.Application.Interfaces;

namespace StockApp.API.Controllers
{
    public class SalesController : Controller
    {
        private readonly ISalesPredictionService _salesPredictionService;

        public SalesController(ISalesPredictionService salesPredictionService)
        {
            _salesPredictionService = salesPredictionService;
        }

        [HttpGet("predict-sales")]
        public ActionResult<double> PredictSales(int productId, int month, int year)
        {
            var predictedSales = _salesPredictionService.PredictSales(productId, month, year);
            return Ok(predictedSales);
        }
    }
}
