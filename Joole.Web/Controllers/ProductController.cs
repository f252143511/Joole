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
        public ActionResult ProductSummary(string subcategory, int beginningYear = 0, int endingYear= 2050, 
            int airflowMinAmount = 1000, int airflowMaxAmount= 9000)
        {
            Service.Service sv = new Service.Service();
            var model = sv.GetProducts(subcategory, beginningYear, endingYear, 
                airflowMinAmount, airflowMaxAmount).ToList();
            ViewData["beginningYear"] = beginningYear;
            ViewData["endingYear"] = endingYear;
            return View(model);
        }
        [HttpGet]
        public ActionResult ProductsCompare(int id1, int id2, int id3)
        {
            Service.Service sv = new Service.Service();
            var model = sv.GetComparison(id1, id2, id3).ToList();

            return View(model);
        }
    }
}