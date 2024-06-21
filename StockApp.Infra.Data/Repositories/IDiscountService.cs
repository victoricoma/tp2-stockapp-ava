using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Infra.Data.Repositories
{
    public interface IDiscountService
    {
        decimal ApplyDiscount(decimal price, decimal discountPercentage);
    }
}
