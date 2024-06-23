using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Entities
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}