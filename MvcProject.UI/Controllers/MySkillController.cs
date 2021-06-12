using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.UI.Controllers
{
    public class MySkillController : Controller
    {
        IMySkillService _mySkillService;

        public MySkillController(IMySkillService mySkillService)
        {
            _mySkillService = mySkillService;
        }

        // GET: MySkill
        public ActionResult Index()
        {
            var mySkills = _mySkillService.getAll();
            return View(mySkills);
        }
    }
}