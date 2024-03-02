using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Models
{
    public class GalleryImages
    {
        [Key]
        public int Id { get; set; }

        public Website Website { get; set; }
        public int WebsiteId { get; set; }
        public string Img { get; set; }
        public int Order { get; set; }
    }
}
