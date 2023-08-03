using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using James_thew_2.Models.DB_Models;

namespace James_thew_2.Controllers
{
    public class Manage_AdminController : Controller
    {
        james_thew_recipesContext db = new james_thew_recipesContext();
        
        public IActionResult users()
        {
            var res = db.Users.ToList();
            return View(res);
        }
    }
}
