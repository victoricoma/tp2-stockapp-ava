using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Interfaces
{
    public interface ISentimentAnalysisService
    {
        SentimentResult AnalyzeSentiment(string text);
    }

    public class SentimentResult
    {
        public double Score { get; internal set; }
    }
}
