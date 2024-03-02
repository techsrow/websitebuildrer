using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Models
{
    public class WhyChooseUs
    {
        public int WhyChooseUsId { get; set; }

        public string SectionName { get; set; }
        public string SectionTagLine { get; set; }

        public string Title { get; set; }

        public string TitleSubText { get; set; }
        public string Photo { get; set; }
        public string heading { get; set; }

        public int WebsiteId { get; set; }
        public Website Website { get; set; }
    }
}
