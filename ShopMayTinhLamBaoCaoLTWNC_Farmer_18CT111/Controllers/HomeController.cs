using Models.Core.Dao;
using ShopMayTinhLamBaoCaoLTWNC_Farmer_18CT111.Common;
using ShopMayTinhLamBaoCaoLTWNC_Farmer_18CT111.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopMayTinhLamBaoCaoLTWNC_Farmer_18CT111.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Slides = new SlideDao().ListAll();
            var productDao = new ProductDao();
            ViewBag.NewProducts = productDao.ListNewProduct(15);
            ViewBag.ListFeatureProducts = productDao.ListFeatureProduct(15);
            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600 * 24)]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroupId(1);
            return PartialView(model);
        }
        [ChildActionOnly]
        [OutputCache(Duration = 3600 * 24)]
        public ActionResult TopMenu()
        {
            var model = new MenuDao().ListByGroupId(2);
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<Cartitem>();
            if (cart != null)
            {
                list = (List<Cartitem>)cart;
            }

            return PartialView(list);
        }
        [ChildActionOnly]
        [OutputCache(Duration = 3600 * 24)]
        public ActionResult Footer()
        {
            var model = new FooterDao().GetFooter();
            return PartialView(model);
        }
    }
}