using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteBuilder.Models;

namespace WebsiteBuilder.ViewModels
{
    public class AdminViewModel
    {
        public string User  { get; set; }
        public Website Website { get; set; }

       

        public  int Click { get; set; }
    }


  
}
