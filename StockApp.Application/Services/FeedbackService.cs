using StockApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly ISentimentAnalysisService _sentimentAnalysisService;

        public FeedbackService(ISentimentAnalysisService sentimentAnalysisService)
        {
            _sentimentAnalysisService = sentimentAnalysisService;
        }

        public async Task SubmitFeedbackAsync(string userId, string feedback)
        {
            var sentiment = _sentimentAnalysisService.AnalyzeSentiment(feedback);

            // Aqui você implementaria a lógica para armazenar o feedback com o resultado da análise de sentimento
            // Pode ser armazenado em um banco de dados, serviço de armazenamento, etc.
            StoreFeedback(userId, feedback, sentiment);
        }

        private void StoreFeedback(string userId, string feedback, SentimentResult sentiment)
        {
            // Exemplo de armazenamento fictício
            Console.WriteLine($"Feedback from user {userId}: {feedback}");
            Console.WriteLine($"Sentiment score: {sentiment.Score}");
            // Implemente a lógica real de armazenamento conforme necessário
        }
    }
}
