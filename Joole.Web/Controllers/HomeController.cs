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
        //private IUserService userService;
        //private IRepository<User> userRepository;
        //userRepository = new IRepository<User>;
        /* public HomeController(IUserService userService)
        {
            this._userService = userService;
        }
       */
        [HttpGet]
            public ActionResult Index()
        {
            Service.Service sv = new Service.Service();
            var model = sv.GetUsers().ToList();

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