using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.DTOs
{
    public class DashboardStockDTO
    {
        public int TotalProducts { get; set; }
        public decimal TotalStockValue { get; set; }
        public List<ProductStockDTO> LowStockProducts { get; set; }
    }
}
