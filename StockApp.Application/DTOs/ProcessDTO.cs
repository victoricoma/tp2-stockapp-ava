using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.DTOs
{
    public class ProcessDTO
    {
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
        public string Description { get; set; }
        public bool IsAutomated { get; set; }
    }
}