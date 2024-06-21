using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Entities
{
    public class Promotion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Promotion(string name, decimal discountPercentage, DateTime startDate, DateTime endDate)
        {
            Name = name;
            DiscountPercentage = discountPercentage;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
