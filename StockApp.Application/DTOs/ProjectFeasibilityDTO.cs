using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.DTOs
{
    public class ProjectFeasibilityDTO
    {
        public int ProjectId { get; set; }
        public int FeasibilityScore { get; set; }
        public string Comments { get; set; }
    }
}