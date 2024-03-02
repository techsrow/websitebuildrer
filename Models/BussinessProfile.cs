using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Models
{
    public class BussinessProfile
    {
        public int BussinessProfileId { get; set; }

       
        public string Phone { get; set; }

        public string Email { get; set; }

        public string BusinessName { get; set; }

        public string Address { get; set; }

        public string MapUrl { get; set; }

        public string Instagram { get; set; }
        public string Meta { get; set; }
        public string XoldTwitter { get; set; }
        public string youtube { get; set; }
        public string github { get; set; }

        public string LinkedIn { get; set; }



        

    }
}
