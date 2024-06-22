using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public string Sentiment { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
