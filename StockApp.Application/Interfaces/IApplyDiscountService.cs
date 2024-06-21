using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Interfaces
{
    internal interface IApplyDiscountService
    {
        decimal CalculateDiscountedPrice(decimal price, decimal discountPercentage);
    }
}
