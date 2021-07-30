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
        public ActionResult Index(int id)
        {
            Service.Service sv = new Service.Service();
            var model = sv.GetProductDetails(id);
            
            return View(model);
        }
    }
}