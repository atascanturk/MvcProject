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

        public AuthorPanelContentController(IContentService contentService)
        {
            _contentService = contentService;
        }
        public ActionResult MyContent()
        {
            
                var contents = _contentService.GetByAuthorId(3);
                return View(contents);
            }        
    }
}