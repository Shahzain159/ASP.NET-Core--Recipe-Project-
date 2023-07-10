using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using James_Thew.Models.db_models;

namespace James_Thew.Controllers
{
    public class AdminController : Controller
    {
        james_thew_recipesContext db = new james_thew_recipesContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(string email, string password)
        {

            return View();
        }
    }
}
