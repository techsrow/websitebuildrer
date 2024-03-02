using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Controllers
{
    public class ConfirmController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
