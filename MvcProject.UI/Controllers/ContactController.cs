using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.UI.Controllers
{
    public class ContactController : Controller
    {

        IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        ContactValidator validationRules = new ContactValidator();

        // GET: Contact
        public ActionResult Index()
        {
            var contacts = _contactService.GetAll();
            return View(contacts);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contact = _contactService.GetById(id);
            return View(contact);
        }

       
    }
}