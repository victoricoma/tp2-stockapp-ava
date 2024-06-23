using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockApp.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        [NotMapped]
        public List<Product> Products { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
