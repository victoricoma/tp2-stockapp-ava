using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Interfaces
{
    public interface IMarketTrendAnalysisService
    {
        Task<MarketTrendDto> AnalyzeTrendsAsync();
    }

    public class MarketTrendDto
    {
        public string Trend { get; set; }
        public string Prediction { get; set; }
    }
}
