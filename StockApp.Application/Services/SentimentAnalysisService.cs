using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using StockApp.Domain.Interfaces;

namespace StockApp.Application.Services
{
    public class SentimentAnalysisService : ISentimentAnalysisService
    {
        private class SentimentResponse
        {
            public SentimentDocument[] Documents { get; set; }
        }
        private class SentimentDocument
        {
            public string Sentiment { get; set; }
        }

        private readonly string _endpoint;
        private readonly string _apiKey;

        public SentimentAnalysisService(IConfiguration configuration)
        {
            _endpoint = configuration["SentimentAnalysis:Endpoint"];
            _apiKey = configuration["SentimentAnalysis:ApiKey"];
        }
        public async Task<string>AnalyzeSentimentAsync(string text)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription", _apiKey);

            var content = new StringContent(JsonSerializer.Serialize(new { documents = new[] { new { id = "1", language = "pt-br", text }}}), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync($"{_endpoint}/text/analytics/v3.0/sentment", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var sentimentResult = JsonSerializer.Deserialize<SentimentResponse>(responseContent);

            return sentimentResult.Documents[0].Sentiment;
        }
    }
}
