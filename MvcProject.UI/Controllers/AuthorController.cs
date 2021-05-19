using BusinessLayer.Abstract;
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
    public class AuthorController : Controller
    {

        IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public ActionResult Index()
        {
            
            var authors = _authorService.GetAll();
            return View(authors);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
            
        }

        [HttpPost]
        public ActionResult Add(Author author)
        {
            AuthorValidator validationRules = new AuthorValidator();
            ValidationResult results = validationRules.Validate(author);

            if (results.IsValid)
            {
                _authorService.Add(author);
                return RedirectToAction("Index");
            }

            else
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View();
            }

        }

        [HttpGet]
        public ActionResult UpdateAuthor(int id)
        {
            var author = _authorService.GetById(id);

            return View(author);

        }
        [HttpPost]
        public ActionResult UpdateAuthor(Author author)
        {
            AuthorValidator validationRules = new AuthorValidator();
            ValidationResult results = validationRules.Validate(author);

            if (results.IsValid)
            {
                _authorService.Update(author);

                return RedirectToAction("Index");
            }

            else
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View();
            }

            
                }
        }
}