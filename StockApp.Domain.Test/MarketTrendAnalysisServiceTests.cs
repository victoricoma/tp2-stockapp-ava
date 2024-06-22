using StockApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using StockApp.Application.Services;

namespace StockApp.Domain.Test
{
    public class MarketTrendAnalysisServiceTests
    {
        private readonly IMarketTrendAnalysisService _marketTrendAnalysisService;

        public MarketTrendAnalysisServiceTests()
        {
            _marketTrendAnalysisService = new MarketTrendAnalysisService();
        }

        [Fact]
        public async Task AnalyzeTrendsAsync_ShouldReturnExpectedResult()
        {
            var result = await _marketTrendAnalysisService.AnalyzeTrendsAsync();

            Assert.Equal("Aumento nas vendas de ingressos.", result.Trend);
            Assert.Equal("Crescimento de 22% nas próximas semanas.", result.Prediction);
        }
    }
}
