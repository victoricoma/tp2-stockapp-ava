using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Services
{
    public interface IPricingService
    {
        Task<decimal> GetProductPriceAsync(string productId);
    }

}
