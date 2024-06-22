using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockApp.Domain.Interfaces;
using StockApp.Domain.Entities;
using AutoMapper;
using StockApp.Infra.Data.Context;

namespace StockApp.Application.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly ISentimentAnalysisService _sentimentAnalysisService;
        private readonly ILogger<FeedbackService> _logger;
        private readonly ApplicationDbContext _dbContext;

        public FeedbackService(ISentimentAnalysisService sentimentAnalysisService, ILogger<FeedbackService> logger, ApplicationDbContext dbContext)
        {
            _sentimentAnalysisService = sentimentAnalysisService;
            _logger = logger;
        }

        public async Task SubmitFeedbackAsync(string userId, string feedback)
        {
            try
            {
                var sentiment = await _sentimentAnalysisService.AnalyzeSentimentAsync(feedback);

                var feedbackEntry = new Feedback
                {
                    UserId = userId,
                    Content = feedback,
                    Sentiment = sentiment,
                    Timestamp = DateTime.UtcNow
                };
                await _dbContext.SaveChangesAsync();

                _logger.LogInformation("Feedback submitted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error submitting feedback for user {UserId}", userId);
                throw;
            }
        }
    }
}

