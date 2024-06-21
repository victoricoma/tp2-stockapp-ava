using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.DTOs
{
    public class ApplyDiscountDTO
    {
        public decimal Price { get; set; }
        public decimal DiscountPercentage { get; set; }
    }
}
