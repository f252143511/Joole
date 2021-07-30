using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Joole.Dal;
using Joole.Repository;
using Joole.Service;

namespace Joole.Web.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public ActionResult ProductSummary()
        {
            Service.Service sv = new Service.Service();
            var model = sv.GetProducts().ToList();

            return View(model);
        }
    }
}