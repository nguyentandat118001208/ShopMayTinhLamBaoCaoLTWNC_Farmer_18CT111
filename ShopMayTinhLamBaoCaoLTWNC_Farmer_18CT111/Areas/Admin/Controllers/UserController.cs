using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Core.EF;
using System.Web.Mvc;
using Models.Core.Dao;
using ShopMayTinhLamBaoCaoLTWNC_Farmer_18CT111.Common;
using PagedList;
namespace thiwebthinghiem2.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                //ẩn                
                var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMd5Pas;
                //
                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Them User thanh cong");
                }
            }
            return View("Index");
        }
    }
}