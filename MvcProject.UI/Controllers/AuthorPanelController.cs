using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.UI.Controllers
{
    public class AuthorPanelController : Controller
    {
        ITitleService _titleService;
        ICategoryService _categoryService;

        public AuthorPanelController(ITitleService titleService, ICategoryService categoryService)
        {
            _titleService = titleService;
            _categoryService = categoryService;
        }

        public ActionResult AuthorProfile()
        {
            return View();
        }

        public ActionResult MyTitles()
        {
          
            var headings = _titleService.GetAllByNonDeleted(3);
            return View(headings);
        }

        [HttpGet]
        public ActionResult NewTitle()
        {
            List<SelectListItem> categoryValues = (from x in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString(),

                                                   }).ToList();
            ViewBag.ValueCategories = categoryValues;
            return View();
        }

        [HttpPost]
        public ActionResult NewTitle(Title title)
        {
            title.AuthorId = 1;
            _titleService.Add(title);
            return RedirectToAction("MyTitles");

        }

        [HttpGet]
        public ActionResult UpdateTitle(int id)
        {
            List<SelectListItem> categoryValues = (from x in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString(),

                                                   }).ToList();
            ViewBag.ValueCategories = categoryValues;
            var updatedTitle = _titleService.GetById(id);
            return View(updatedTitle);
        }
        [HttpPost]
        public ActionResult UpdateTitle(Title title)
        {
            _titleService.Update(title);
            return RedirectToAction("MyTitles");
        }

        [HttpGet]
        public ActionResult DeleteTitle(int id)
        {
            var deletedTitle = _titleService.GetById(id);
            deletedTitle.Status = false;
            _titleService.Update(deletedTitle);
            return RedirectToAction("MyTitles");
        }
    }
}