using StockApp.Application.Interfaces;
using System;

namespace StockApp.Application.Services
{
    public class ReviewModerationService : IReviewModerationService
    {
        public bool ModerateReview(string review)
        {
            return !review.Contains("inapropriado", StringComparison.OrdinalIgnoreCase);
        }
    }
}
