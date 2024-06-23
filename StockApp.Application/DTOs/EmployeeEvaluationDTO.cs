using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.DTOs
{
    public class EmployeeEvaluationDTO
    {
        public int EmployeeId { get; set; }
        public int EvaluationScore { get; set; }
        public string Feedback { get; set; }
    }
}