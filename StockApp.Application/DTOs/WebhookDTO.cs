using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.DTOs
{
    public class WebhookDTO
    {
        public string EventType { get; set; }
        public string EventData { get; set; }
    }
}
