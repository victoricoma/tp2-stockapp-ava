using Microsoft.AspNetCore.Mvc;
using StockApp.Application.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IReviewModerationService _reviewModerationService;

    public ReviewController(IReviewModerationService reviewModerationService)
    {
        _reviewModerationService = reviewModerationService;
    }

    [HttpPost("moderate")]
    public IActionResult ModerateReview(string reviewText)
    {
        bool isApproved = _reviewModerationService.ModerateReview(reviewText);

        if (isApproved)
        {
            return Ok("Review moderada e aprovada.");
        }
        else
        {
            return BadRequest("Review contém conteúdo inapropriado e não pode ser aceita.");
        }
    }
}
