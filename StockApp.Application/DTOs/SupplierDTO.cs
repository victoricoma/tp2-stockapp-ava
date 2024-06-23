using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.DTOs
{
    public class SupplierDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EvaluationScore { get; set; }
    }
}