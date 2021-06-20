using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.UI.Controllers
{
    public class AuthorPanelContentController : Controller
    {
        IContentService _contentService;
        IAuthorService _authorService;

        public AuthorPanelContentController(IContentService contentService, IAuthorService authorService)
        {
            _contentService = contentService;
            _authorService = authorService;
        }

        public ActionResult MyContent()
        {            
            string authorMail = (string)Session["AuthorMail"];
            int id = _authorService.Get(x => x.Mail == authorMail).Id;
            var contents = _contentService.GetByAuthorId(id);
            return View(contents);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.TitleId = id;
            string authorMail = (string)Session["AuthorMail"];
            int authorId = _authorService.Get(x => x.Mail == authorMail).Id;
            ViewBag.AuthorId = authorId;


            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
          
            _contentService.Add(content);
            return RedirectToAction("MyContent");
            
        }

        
    }
}