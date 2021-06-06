using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.UI.Controllers
{
    public class GaleryController : Controller
    {
        IImageService _imageService;

        public GaleryController(IImageService imageService)
        {
            _imageService = imageService;
        }

        // GET: Galery
        public ActionResult Index()
        {
            var images = _imageService.GetAll();
            return View(images);
        }
    }
}