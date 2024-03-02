using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Models
{
    public class Click
    {
        public int ClickId { get; set; }
        public int WebsiteId { get; set; }
        public Website Website { get; set; }
        public string IpAddress { get; set; }

        public string MainUrl { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
