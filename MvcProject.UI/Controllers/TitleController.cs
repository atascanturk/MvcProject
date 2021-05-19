﻿using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.UI.Controllers
{
    public class TitleController : Controller
    {
        // GET: Title

        ITitleService _titleService;
        ICategoryService _categoryService;
        IAuthorService _authorService;

        public TitleController(ITitleService titleService, ICategoryService categoryService, IAuthorService authorService)
        {
            _titleService = titleService;
            _categoryService = categoryService;
            _authorService = authorService;
        }

        public ActionResult Index()
        {                     

            var titles = _titleService.GetAll();
            return View(titles);
        }

        [HttpGet]
        public ActionResult AddTitle()
        {
            //var categories = _categoryService.GetAll();
            List<SelectListItem> categoryValues = (from x in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString(),

                                                   }).ToList();

            List<SelectListItem> authorValues = (from x in _authorService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name +" "+ x.LastName,
                                                       Value = x.Id.ToString(),

                                                   }).ToList();

            ViewBag.ValueCategories = categoryValues;
            ViewBag.ValueAuthors = authorValues;
           return View();
        }

        [HttpPost]
        public ActionResult AddTitle(Title title)
        {
            _titleService.Add(title);
            return RedirectToAction("Index");
        }
    }
}