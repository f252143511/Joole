using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Joole.Dal;
using Joole.Repository;
using Joole.Service;
using Joole.Web.Models;

namespace Joole.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
            public ActionResult Index()
        {
            UserService userService = new UserService();

            List<UserViewModel> model = new List<UserViewModel>();
            userService.GetUsers().ToList().ForEach(u =>
            {
                UserViewModel user = new UserViewModel
                {
                    Id = u.User_ID,
                    Username = u.Username,
                    Email = u.Email
                };
                model.Add(user);
            });

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}