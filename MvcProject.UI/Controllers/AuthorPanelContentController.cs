using BusinessLayer.Abstract;
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
    }
}