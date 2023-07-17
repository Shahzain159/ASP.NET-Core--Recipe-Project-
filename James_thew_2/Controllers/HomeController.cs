using James_thew_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace James_thew_2.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Recipes()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

      
    }
}
