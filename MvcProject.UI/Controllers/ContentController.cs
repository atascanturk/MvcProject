﻿using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.UI.Controllers
{
    public class ContentController : Controller
    {
        IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByTitle(int id)
        {
            var contents = _contentService.GetByTitleId(id);
            return View(contents);
        }
    }
}