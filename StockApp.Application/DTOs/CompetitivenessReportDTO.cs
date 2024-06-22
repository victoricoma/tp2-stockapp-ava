using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.DTOs
{
    public class CompetitivenessReportDto
    {
        public int CompanyScore { get; set; }
        public int CompetitorScore { get; set; }
        public int CompetitiveEdge { get; set; }
    }
}
