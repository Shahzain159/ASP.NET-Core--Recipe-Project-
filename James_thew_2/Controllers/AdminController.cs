using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using James_thew_2.Models.DB_Models;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace James_thew_2.Controllers
{
    public class AdminController : Controller
    {
        james_thew_recipesContext db = new james_thew_recipesContext();
        public IActionResult Index()
        {
            //var affectedRows = db.Database.ExecuteSqlRaw("usp_CreateAuthor @AuthorName, @Email");

            return View();
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(TblAdmin admin)
        {
            bool is_admin = db.TblAdmins.Any(x=>x.AEmail == admin.AEmail && x.APassword == admin.APassword);
            if (is_admin)
            {
                var data = db.TblAdmins.Where(x => x.AEmail == admin.AEmail && x.APassword == admin.APassword).FirstOrDefault();
                HttpContext.Session.SetString("admin_login_id",data.AId.ToString());

                return RedirectToAction("Index");
            }
            else
            {
                TempData["login_error"] = "Email or Password is Wrong";
                return View();
            }
        }
    }
}
