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
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            Service.Service sv = new Service.Service();
            ViewBag.CategoryList = new SelectList(sv.GetCategoryListAll(), "Category_ID", "Category_Name");
            ViewBag.SubCategoryList = new SelectList(sv.GetSubCategoryListAll(), "SubCategory_ID", "SubCategoryName");
            return View();
        }

        public ActionResult ChangeCategory(int Category_ID)
        {
            Service.Service sv = new Service.Service();
            ViewBag.SubCategoryOptions = new SelectList(sv.GetSubCategoryList(Category_ID), "SubCategory_ID", "SubCategoryName");
            return PartialView("SubCategoryOptionsPartial");
        }

        public ActionResult SearchSubmit(String SubCategoryName)
        {
            Service.Service sv = new Service.Service();
            ViewBag.SubCategory_ID = sv.GetSubcategoryId(SubCategoryName);
            return View();
        }
    }
}