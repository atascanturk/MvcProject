using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using MvcProject.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.UI.Controllers
{
    public class ChartController : Controller
    {
        ICategoryService _categoryService;

        public ChartController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(CategoryChartWithTitle(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryWithTitle> CategoryChartWithTitle()
        {
            var categories = _categoryService.GetAll();
            var categoryList = new List<CategoryWithTitle>();

            foreach (var item in categories)
            {
                CategoryWithTitle category = new CategoryWithTitle { CategoryName = item.Name, TitleCount = item.Titles.Count };
                categoryList.Add(category);
            }

            return categoryList;
        }
    }
}