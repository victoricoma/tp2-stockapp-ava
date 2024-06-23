using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.DTOs
{
    public class CustomReportDTO
    {
        public string Title { get; set; }
        public List<ReportDataDTO> Data { get; set; }
    }
}
