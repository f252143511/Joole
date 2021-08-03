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
            int airflowMinAmount = 1000, int airflowMaxAmount= 9000,
            double powerMinAmount = 10, double powerMaxAmount = 65,
            int soundMinAmount = 20, int soundMaxAmount = 50,
            int sweepMinAmount = 18, int sweepMaxAmount = 60)
        {
            Service.Service sv = new Service.Service();
            var model = sv.GetProducts(subcategory, beginningYear, endingYear, 
                airflowMinAmount, airflowMaxAmount,
                powerMinAmount, powerMaxAmount,
                soundMinAmount, soundMaxAmount,
                sweepMinAmount, sweepMaxAmount).ToList();
            ViewData["beginningYear"] = beginningYear;
            ViewData["endingYear"] = endingYear;
            ViewData["airflowMinAmount"] = airflowMinAmount;
            ViewData["airflowMaxAmount"] = airflowMaxAmount;
            ViewData["powerMinAmount"] = powerMinAmount;
            ViewData["powerMaxAmount"] = powerMaxAmount;
            ViewData["soundMinAmount"] = soundMinAmount;
            ViewData["soundMaxAmount"] = soundMaxAmount;
            ViewData["sweepMinAmount"] = sweepMinAmount;
            ViewData["sweepMaxAmount"] = sweepMaxAmount;
            return View(model);
        }
        [HttpGet]
        public ActionResult ProductsCompare(int id1 = 0, int id2 = 0, int id3 = 0)
        {
            Service.Service sv = new Service.Service();
            var model = sv.GetComparison(id1, id2, id3).ToList();

            return View(model);
        }
    }
}