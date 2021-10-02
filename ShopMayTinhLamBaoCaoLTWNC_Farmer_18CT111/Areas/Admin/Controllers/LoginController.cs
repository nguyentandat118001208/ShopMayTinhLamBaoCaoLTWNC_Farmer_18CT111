using ShopMayTinhLamBaoCaoLTWNC_Farmer_18CT111.Areas.Admin.Models;
using ShopMayTinhLamBaoCaoLTWNC_Farmer_18CT111.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Core.Dao;
using System.Data.SqlClient;
using System.Web.Security;
using Models.Core;

namespace ShopMayTinhLamBaoCaoLTWNC_Farmer_18CT111.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {

            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "tai khoan khong ton tai");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "tai khoan dang bi khoa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "tai khoan dang bi khoa");
                }
                else
                {
                    ModelState.AddModelError("", "dang nhap khong dung");
                }
            }
            return View("Index");
        }
    }
}
