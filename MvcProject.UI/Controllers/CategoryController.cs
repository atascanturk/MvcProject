
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager;

        public CategoryController(CategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }



        // GET: Category
        public ActionResult Index()
        {
          
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categories = _categoryManager.GetAll();
            return View(categories);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
           //_categoryManager.Add(category);
           return RedirectToAction("GetCategoryList");
        }
    }
}