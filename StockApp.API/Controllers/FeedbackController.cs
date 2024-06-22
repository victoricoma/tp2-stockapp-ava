using Microsoft.AspNetCore.Mvc;
using StockApp.Domain.Interfaces;

namespace StockApp.API.Controllers
{
    public class FeedbackRequest
    {
        public string UserId { get; set; }
        public string Feedback { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitFeedback([FromBody] FeedbackRequest request)
        {
            if (string.IsNullOrEmpty(request.UserId) || string.IsNullOrEmpty(request.Feedback))
            {
                return BadRequest("Complete the fields");
            }

            await _feedbackService.SubmitFeedbackAsync(request.UserId, request.Feedback);

            return Ok("Feedback submitted successfully");
        }
    }
}
