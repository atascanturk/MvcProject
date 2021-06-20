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
   [AllowAnonymous]
    public class LoginController : Controller
    {
        IAdminService _adminService;
        IAuthorService _authorService;

        public LoginController(IAdminService adminService, IAuthorService authorService)
        {
            _adminService = adminService;
            _authorService = authorService;
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

        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AuthorLogin(Author author)
        {
            var authorUser = _authorService.Get(x => x.Mail == author.Mail && x.Password == author.Password);            
            if (authorUser != null)
            {
                FormsAuthentication.SetAuthCookie(authorUser.Mail, false);
                Session["AuthorMail"] = authorUser.Mail;
                Session["AuthorName"] = $"{authorUser.Name} {authorUser.LastName}";
                return RedirectToAction("MyContent", "AuthorPanelContent");
            }

            else
            {
                ModelState.AddModelError("PasswordOrUserNameError", "Kullanıcı adı ve/veya şifre hatalı.");
                return View();
            }
            
        }

        public ActionResult LogOut ()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin");
        }
    }
}