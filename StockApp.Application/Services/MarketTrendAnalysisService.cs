using StockApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Services
{
    public class MarketTrendAnalysisService : IMarketTrendAnalysisService
    {
        public async Task<MarketTrendDto> AnalyzeTrendsAsync()
        {
            return new MarketTrendDto
            {
                Trend = "Aumento nas vendas de ingressos.",
                Prediction = "Crescimento de 22% nas próximas semanas."
            };
        }
    }
}
