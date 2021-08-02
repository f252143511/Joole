using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Joole.Dal;
using Joole.Repository;
using Joole.Service;

namespace Login.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            ViewData["AuthError"] = "";
            return View(new User());
            
        }
        public ActionResult Submit(User obj)
        {
            Service sv = new Service();
            String useremail = Request.Form["Useremail"];
            String password = Request.Form["Password"];
            obj.Username = useremail;
            obj.Password = password;
            if (sv.ValidateUser(useremail, password))
            {
                return RedirectToAction("Index", "Search");
            }
            else
            {
                // ModelState.AddModelError("Useremail", "Incorrect Credentials");
                ViewData["AuthError"] = "Invalid credentials!";
                return View("Login", obj);
            }
        }
        public PartialViewResult Register()
        {
            return PartialView("_Register");
        }
        public ActionResult Registration()
        {

            ViewData["AuthError"] = "";
            if (Request.Form["password"] != Request.Form["password2"])
            {
                ViewData["Image"] = Request.Form["picture"];
                var i = ViewData["Image"];
                ViewData["Username"] = Request.Form["user"];
                ViewData["Email"] = Request.Form["email"];
                ModelState.AddModelError("password2", "Please confirm password.");
                return View("Login", new User());
            }
            Service sv = new Service();
            string username = Request.Form["user"];
            string password = Request.Form["password"];
            string email = Request.Form["email"];
            string image = Request.Form["picture"];
            User u = new User(username, password, email, image);
            sv.CreateUser(u);
            
            return View("Login", new User());
        }
    }
}