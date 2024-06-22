using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockApp.Application.DTOs;

namespace StockApp.Application.Interfaces
{
    public interface IMarketTrendAnalysisService
    {
        Task<MarketTrendDTO> AnalyzeTrendsAsync();
    }
}
