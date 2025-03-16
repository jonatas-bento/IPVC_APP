using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPBVC_App.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; } = DateTime.Now;  // Default to today
        public string EventLocation { get; set; }
        public string EventDescription { get; set; }
    }
}
