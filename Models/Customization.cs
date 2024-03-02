using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Models
{
    public class Customization
    {
        public int CustomizationId  { get; set; }
        public string ThemeColor { get; set; }

        public string headingColor { get; set; }

        public string SubheadingColor { get; set; }

        public string TextColor { get; set; }

        public string PrimaryBgColor { get; set; }

        public string SecondryBgColor { get; set; }

        public int WebsiteId { get; set; }
        public Website Website { get; set; }
    }
}
