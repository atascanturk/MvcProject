using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.UI.Controllers
{
    public class AdminController : Controller
    {

        IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }


        // GET: Admin
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(AdminAddDto adminAddDto ,string password)
        {
            if (adminAddDto.Password==adminAddDto.PasswordRepeat)
            {
                
                _adminService.Add(adminAddDto, password);
                ViewBag.Message = "Başarıyla Eklendi";
                return View();
            }

            else
            {
                ModelState.AddModelError("Password","Parolalar birbiri ile uyuşmuyor.");
               
            }

            return View();
        }

        [HttpGet]
        public ActionResult UpdateAdminRole(int id)
        {
            var admin = _adminService.Get(x => x.Id == id);
            return View(admin);
        }

        [HttpPost]
        public ActionResult UpdateAdminRole(string role, int id)
        {

            var admin = _adminService.Get(x => x.Id == id);
            admin.Role = role;
            _adminService.Update(admin);
            return RedirectToAction("Index","Auth");
        }
    }
}