using Microsoft.AspNetCore.Mvc;
using StockApp.Domain.Interfaces;
using StockApp.Application.Services;
using StockApp.Application.DTOs;

namespace StockApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarketTrendController : ControllerBase
    {
        private readonly IMarketTrendAnalysisService _marketTrendAnalysisService;

        public MarketTrendController(IMarketTrendAnalysisService marketTrendAnalysisService)
        {
            _marketTrendAnalysisService = marketTrendAnalysisService;
        }

        [HttpGet("analyze")]
        public async Task<ActionResult<MarketTrendDto>> AnalyzeTrends()
        {
            var result = await _marketTrendAnalysisService.AnalyzeTrendsAsync();
            return Ok(result);
        }
    }
}
