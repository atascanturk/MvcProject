using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MvcProject.UI.Controllers
{
    public class DefaultController : Controller
    {
        ITitleService _titleService;
        IContentService _contentService;

        public DefaultController(ITitleService titleService, IContentService contentService)
        {
            _titleService = titleService;
            _contentService = contentService;
        }


        // GET: Default
        public PartialViewResult Index(int? id)
        {
            var contents = id == null
              ? _contentService.GetAll() :
               _contentService.GetByTitleId((int)id);

            return PartialView(contents);                 

        }

        [AllowAnonymous]
        public ActionResult Titles()
        {

            var titles = _titleService.GetAll();            
            return View(titles);
        }
    }
}