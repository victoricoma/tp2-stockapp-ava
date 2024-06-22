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
    }
}
