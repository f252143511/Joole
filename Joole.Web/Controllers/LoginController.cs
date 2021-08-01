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
            Service sv = new Service();
            String useremail = Request.Form["Useremail"];
            String password = Request.Form["Password"];
            if (sv.validateUser(useremail,password))
            {
                return RedirectToAction("Index", "Search");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Registration()
        {
            Service sv = new Service();
            string username = Request.Form["user"];
            string password = Request.Form["password"];
            string email = Request.Form["email"];
            string image = Request.Form["picture"];
            User u = new User(username, password, email, image);
            sv.CreateUser(u);
            return View("Login");
        }
    }
}