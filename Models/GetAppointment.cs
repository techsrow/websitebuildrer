using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Models
{
    public class GetAppointment
    {
        public int GetAppointmentId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }

        public string ButtonText { get; set; }
        public string BtnNumber { get; set; }

        public int WebsiteId { get; set; }
        public Website Website { get; set; }
    }
}
