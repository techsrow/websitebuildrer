using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Models
{
    public class Service
    {
        public int ServiceId { get; set; }

        public string TitleSubText { get; set; }
        public string ServiceName { get; set; }
        public string ServiceImage { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceShortDesc { get; set; }

        public string ServiceUrl { get; set; }

        public int WebsiteId { get; set; }
        public Website Website { get; set; }

    }
}
