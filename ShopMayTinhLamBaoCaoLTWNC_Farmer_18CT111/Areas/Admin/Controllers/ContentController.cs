using Models.Core.Dao;
using Models.Core.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopMayTinhLamBaoCaoLTWNC_Farmer_18CT111.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {

            var dao = new ContentDao();
            var model = dao.ListAllPagingContent(searchString, page, pageSize);
            ViewBag.SearchString = searchString; // gán vào một cái viewbag để cái View nhận được
            return View(model);
        }

        public ActionResult CreateContent()
        {
            SetViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult EditContent(long id)
        {
            var dao = new ContentDao();
            var content = dao.GetByID(id);

            SetViewBag(content.CategoryID);

            return View(content);
        }
        [HttpPost]
        public ActionResult EditContent(Content_ model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDao();
                //ẩn                               
                //
                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    ModelState.AddModelError("", "Sua Content thanh cong");
                }
            }
            SetViewBag(model.CategoryID);
            return View("Index");
        }
        [HttpPost]
        public ActionResult CreateContent(Content_ model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDao();
                //ẩn                                             
                //
                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    ModelState.AddModelError("", "Them Content thanh cong");
                }
            }
            SetViewBag();
            return View("Index");
        }
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ContentDao().Delete(id);

            return RedirectToAction("Index");
        }
    }
}