using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Core.EF;

namespace ShopMayTinhLamBaoCaoLTWNC_Farmer_18CT111.Areas.Admin.Controllers
{

    public class CategoryController : Controller
    {       

        // GET: Admin/Category

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateCategory()
        {
            return View();
        }

    }
}