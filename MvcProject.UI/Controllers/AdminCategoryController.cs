using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.UI.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager _categoryManager;

        public AdminCategoryController(CategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public ActionResult Index()
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
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(category);
            if (validationResult.IsValid)
            {
                _categoryManager.Add(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var category = _categoryManager.GetById(id);
            _categoryManager.Delete(category);
            return RedirectToAction("Index", "AdminCategory");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var updatedCategory = _categoryManager.GetById(id);
            return View(updatedCategory);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
             _categoryManager.Update(category);
            return RedirectToAction("Index");
        }
    }
}