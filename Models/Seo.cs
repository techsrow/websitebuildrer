using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Models
{
    public class Seo
    {
        public int SeoId { get; set; }
        public string SeoTitle { get; set; }

        public string MetaDescription { get; set; }
        public string canonicalUrl { get; set; }
        public string OgTitle { get; set; }
        public string OgDescription { get; set; }

        public string OgUrl { get; set; }
        public string SiteName { get; set; }

        public string OgImageUrl { get; set; }

        public string TwitterImageUrl { get; set; }

        public string authorname { get; set; }

        public string MetaTagsForFacebook { get; set; }
        public string MetaTagsForInstagram { get; set; }

        public string GoogleAnalytics { get; set; }

        public string CustomScript { get; set; }

        public string SiteMap { get; set; }

        public int WebsiteId { get; set; }
        public Website Website { get; set; }
    }
}
