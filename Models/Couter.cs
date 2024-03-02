using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Models
{
    public class Couter
    {
        [Key]
        public int CounterId { get; set; }

        public string Title { get; set; }
        public string StartNumber { get; set; }
        public string EndNumber { get; set; }

        public int WebsiteId { get; set; }
        public Website Website { get; set; }

    }
}
