using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Core.Dao;
//32 quang
namespace ShopMayTinhLamBaoCaoLTWNC_Farmer_18CT111.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult ProductCategory()

        {
            var model = new ProductCategoryDao().ListAll();
            return PartialView(model);
        }
        public ActionResult Category(long cateId)
        {
            var category = new CategoryDao().ViewDetail(cateId);
            return View(category);
        }
        public ActionResult Detail(long id)
        {
            var product = new ProductDao().Viewdetail(id);
            ViewBag.Category = new ProductCategoryDao().ViewDetail(product.CategoryID.Value);
            ViewBag.RelatedProducts = new ProductDao().ListRelateProducts(id);
            return View(product);
        }
    }
}