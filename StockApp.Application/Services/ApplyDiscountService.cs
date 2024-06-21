using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockApp.Application.Interfaces;

namespace StockApp.Application.Services
{
    public class ApplyDiscountService : IApplyDiscountService
    {
        public decimal CalculateDiscountedPrice(decimal price, decimal discountPercentage)
        {
            return price - (price * discountPercentage / 100);
        }
    }
}
