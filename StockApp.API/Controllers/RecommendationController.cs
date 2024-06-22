using Microsoft.AspNetCore.Mvc;
using StockApp.Domain.Interfaces;

namespace StockApp.API.Controllers
{
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;

        public RecommendationController(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult>GetRecommendations(string userId)
        {
            var recommendations = await _recommendationService.GetRecommendationsAsync(userId);
            
            return Ok(recommendations);
        }
    }
}
