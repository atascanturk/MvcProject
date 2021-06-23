using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using PagedList;
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
        IAuthorService _authorService;

        public AuthorPanelController(ITitleService titleService, ICategoryService categoryService, IAuthorService authorService)
        {
            _titleService = titleService;
            _categoryService = categoryService;
            _authorService = authorService;
        }
       
        public ActionResult AuthorProfile()
        {
            string authorMail = (string)Session["AuthorMail"];
            var author = _authorService.GetAll(x => x.Mail == authorMail).FirstOrDefault();
            return View(author);
        }

        public ActionResult MyTitles()
        {
            string authorMail = (string)Session["AuthorMail"];
            int id = _authorService.Get(x => x.Mail == authorMail).Id;
            var headings = _titleService.GetAllByNonDeleted(id);
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
            string authorMail = (string)Session["AuthorMail"];
            title.AuthorId = _authorService.Get(x => x.Mail == authorMail).Id;
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

        public  ActionResult AllTitles(int start =1)
        {
            var titles = _titleService.GetAll().ToPagedList(start, 4);
            return View(titles);
        }
    }
}