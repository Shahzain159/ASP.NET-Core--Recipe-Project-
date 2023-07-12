using James_thew_2.Models.DB_Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace James_thew_2.Controllers
{
    public class Recipe_AdminController : Controller
    {
        james_thew_recipesContext db = new james_thew_recipesContext();
        IWebHostEnvironment env;

        public Recipe_AdminController(IWebHostEnvironment env)
        {
            this.env = env;
        }

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
            ViewBag.CategoryId = db.Categories
                .Select(c => new SelectListItem() { Text = c.CategoryName, Value = c.CategoryId.ToString() })
                .ToList();

            ViewBag.rec_data = db.Recipes.Include(x=>x.Category).ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Recipes(Recipe r , IFormFile r_image ,int free_mem)
        {
            if (r_image == null || r_image.Length == 0)
            {
                TempData["image_error"] = "Image Is Empty";
                return RedirectToAction("Recipes");
            }
            else
            {
                var file_name = Guid.NewGuid() + r_image.FileName;
                var file_path = Path.Combine(env.WebRootPath, "img/recipes");
                var final_path = Path.Combine(file_path, file_name);

                var FS = new FileStream(final_path, FileMode.Create);

                r_image.CopyTo(FS);
                
                r.RecipeImage = "/img/recipes/" + file_name;

                r.UserId =7;
                r.CreatedDate = DateTime.Now;
                r.IsFree = Convert.ToBoolean(free_mem);

                db.Recipes.Add(r);
                db.SaveChanges();

                FS.Close();

                TempData["recip_succ"] = "Recipe Added Successfully";
                return RedirectToAction("recipes");
            }
        }
        public IActionResult Ingredients()
        {
            ViewBag.RecipeId = db.Recipes
                .Select(c => new SelectListItem() { Text = c.RecipeTitle, Value = c.RecipeId.ToString() })
                .ToList();
            ViewBag.i_data = db.Ingredients.Include(x => x.Recipe).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Ingredients(Ingredient i)
        {
            db.Ingredients.Add(i);
            db.SaveChanges();
            TempData["ing_succ"] = "Ingredients Added";
            return RedirectToAction("Ingredients");
        }
        public IActionResult Steps()
        {
            ViewBag.RecipeId = db.Steps
                .Select(c => new SelectListItem() { Text = c.Recipe.RecipeTitle, Value = c.RecipeId.ToString() })
                .ToList();

            ViewBag.s_data = db.Steps.Include(x => x.Recipe).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Steps(Step s)
        {
            db.Steps.Add(s);
            db.SaveChanges();
            TempData["s_succ"] = "Step Added";
            return RedirectToAction("Steps");
        }
    }
}
