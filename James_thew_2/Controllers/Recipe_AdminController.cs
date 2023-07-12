using James_thew_2.Models.DB_Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace James_thew_2.Controllers
{
    public class Recipe_AdminController : Controller
    {
        james_thew_recipesContext db = new james_thew_recipesContext();

        public IActionResult Categories()
        {

            var res = db.Categories.OrderBy(x=>x.CategoryName).ToList();
            ViewBag.cat_data = res;

            return View();
        }
        [HttpPost]
        public IActionResult Categories(Category c)
        {
            if (db.Categories.Any(x=>x.CategoryName == c.CategoryName))
            {
                TempData["cat_already"] = "Category Already Exist";
                return View();
            }
            else
            {
                db.Categories.Add(c);
                db.SaveChanges();
                TempData["cat_inserted"] = "Category Added";
                return RedirectToAction("Categories");
            }
          
        }
        public IActionResult Recipes()
        {
            return View();
        }
        public IActionResult Ingredients()
        {
            return View();
        }
        public IActionResult Steps()
        {
            return View();
        }
    }
}
