using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
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
        public ActionResult Index(AdminForLoginDto adminForLoginDto)
        {
            var isAuthorizated = _adminService.GetByUserEmailAndPassword(adminForLoginDto);


            if (isAuthorizated)
            {
                var admin = _adminService.Get(x => x.Email == adminForLoginDto.Email);
                FormsAuthentication.SetAuthCookie(admin.UserName, false);
                Session["UserName"] = admin.UserName;
                return  RedirectToAction("Index", "AdminCategory");
            }

            else
            {
                ModelState.AddModelError("PasswordOrUserNameError", "Kullanıcı adı ve/veya şifre hatalı.");
                return View();
            }
           
        }
    }
}