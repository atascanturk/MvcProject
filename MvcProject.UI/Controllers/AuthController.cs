using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.UI.Controllers
{
    public class AuthController : Controller
    {
        IAdminService _adminService;

        public AuthController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        // GET: Auth
        public ActionResult Index()
        {
            var admins = _adminService.GetAll();
            return View(admins);
        }

    }
}