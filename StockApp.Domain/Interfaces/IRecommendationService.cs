using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockApp.Domain.Entities;

namespace StockApp.Domain.Interfaces
{
    public interface IRecommendationService
    {
        Task<IEnumerable<Product>> GetRecommendationsAsync(string userId);
    }
}
