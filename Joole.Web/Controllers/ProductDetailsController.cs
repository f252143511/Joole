using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Joole.Web.Controllers
{
    public class ProductDetailsController : Controller
    {
        // GET: ProductDetails
        [HttpGet]
        public ActionResult Index()
        {
            Service.Service sv = new Service.Service();
            var model = sv.GetProductDetails(2);
            
            return View(model);
        }
    }
}