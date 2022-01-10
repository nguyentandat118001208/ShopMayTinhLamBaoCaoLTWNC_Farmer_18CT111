using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Core.EF;
using System.Web.Mvc;
using Models.Core.Dao;
using ShopMayTinhLamBaoCaoLTWNC_Farmer_18CT111.Common;
using PagedList;
namespace ShopMayTinhLamBaoCaoLTWNC_Farmer_18CT111.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        [HasCredential(RoleID ="VIEW_USER")]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString; // gán vào một cái viewbag để cái View nhận được
            return View(model);
        }
        [HttpGet]
        [HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [HasCredential(RoleID = "ADD_USER")]
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
        //Phạm Nhờ Đạt : edit user
        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }



        // phạm nhờ Đạt : edit User
        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    //ẩn    
                    var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                    user.Password = encryptedMd5Pas;
                    //
                }

                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "cap nhat User thanh cong");
                }
            }
            return View("Index");
        }


        //Phạm Nhờ Đạt : Delete User
        [HttpDelete]
        [HasCredential(RoleID = "DELETE_USER")]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);

            return RedirectToAction("Index");
        }
        [HasCredential(RoleID = "EDIT_USER")]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result

            });
        }
    }
}