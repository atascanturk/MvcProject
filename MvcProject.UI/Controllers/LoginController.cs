using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProject.UI.Controllers
{
    public class LoginController : Controller
    {
        IAdminService _adminService;

        public LoginController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var adminUser = _adminService.GetByUserNameAndPassword(admin.UserName, admin.Password);


            if (adminUser != null)
            {
                FormsAuthentication.SetAuthCookie(adminUser.UserName, false);
                Session["UserName"] = adminUser.UserName;
                return  RedirectToAction("Index", "AdminCategory");
            }

            else
            {
                RedirectToAction("Index");
            }
            return View();
        }
    }
}