using James_thew_2.Models;
using James_thew_2.Models.DB_Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace James_thew_2.Controllers
{
    public class HomeController : Controller
    {
        james_thew_recipesContext db = new james_thew_recipesContext();
        IWebHostEnvironment env;

        public HomeController(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public IActionResult Index()
        {

            return View();
        }
        
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User u , string me_type , IFormFile profile_pic)
        {
            if (profile_pic == null || profile_pic.Length == 0)
            {
                TempData["image_error"] = "Image Is Empty";
                return RedirectToAction("Register");
            }
            else
            {
                var file_name = Guid.NewGuid() + profile_pic.FileName;
                var file_path = Path.Combine(env.WebRootPath, "img/users");
                var final_path = Path.Combine(file_path, file_name);

                var FS = new FileStream(final_path, FileMode.Create);

                profile_pic.CopyTo(FS);

                u.ProfilePic = "/img/users/" + file_name;
                u.RegistrationDate = DateTime.Now;
                u.PaymentStatus = false;
                u.MembershipType = me_type;
                db.Users.Add(u);
                db.SaveChanges();

                FS.Close();

                TempData["user_success"] = "User Registered";
                return RedirectToAction("Login");
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email , string password)
        {
            var res = db.Users.Any(x=>x.Email == email && x.Password == password);

            if (res)
            {
                var user = db.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
                HttpContext.Session.SetString("login_user_id",user.UserId.ToString());
                HttpContext.Session.SetString("login_user_name", user.Username);

                return RedirectToAction("Index","Home");
            }
            else
            {
                TempData["login_user_error"] = "Email or Password is Wrong";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("login_user_id");
            HttpContext.Session.Remove("login_user_name");

            return RedirectToAction("Index");
        }


        public IActionResult Recipes()
        {
            var rec = db.Recipes.ToList();
            ViewBag.rec = rec;
            return View();
        }
        public IActionResult single_rec(int data)
        {
            ViewBag.recipe = db.Recipes.Where(x=>x.RecipeId == data).FirstOrDefault();
            ViewBag.steps = db.Steps.Where(x=>x.RecipeId == data).ToList();
            ViewBag.ing = db.Ingredients.Where(x => x.RecipeId == data).ToList();

            var comments = db.Comments.Where(x => x.RecipeId == data).Include(x => x.User)
                .Select(p=> new comment_user
                {
                    c_id = p.CommentId,
                    c_text = p.CommentText,
                    c_date = Convert.ToDateTime(p.CommentDate),
                    c_profile = p.User.ProfilePic,
                    c_name = p.User.Username
                }).ToList();

            ViewBag.comm = comments;

            //ViewBag.comm = db.Comments.Where(x=>x.RecipeId == data).ToList();
            //ViewBag.comm2 = db.Comments.Where(x=>x.RecipeId == data).Include(x=>x.User).ToList();

            return View();
        }
        [HttpPost]
        public IActionResult post_comment(string message , string rec_id)
        {
            var c = new Comment();
            c.CommentText = message;
            c.RecipeId = Convert.ToInt32(rec_id);
            c.CommentDate = DateTime.Now;
            c.UserId = Convert.ToInt32(HttpContext.Session.GetString("login_user_id"));

            db.Comments.Add(c);
            db.SaveChanges();

            return RedirectToAction("single_rec","Home",new { data = rec_id} );
        }
        public IActionResult Privacy()
        {
            return View();
        }

      
    }
}
