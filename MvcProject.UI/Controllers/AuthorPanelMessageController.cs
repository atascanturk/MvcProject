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
    public class AuthorPanelMessageController : Controller
    {

        IMessageService _messageService;
        MessageValidator validationRules = new MessageValidator();

        public AuthorPanelMessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }


        public ActionResult Inbox()
        {
            string authorMail = (string)Session["AuthorMail"];
            var messages = _messageService.GetAllForInbox(x => x.To == authorMail);
            return View(messages);
        }

        public ActionResult SentMessages()
        {

            string authorMail = (string)Session["AuthorMail"];
            var sentMessages = _messageService.GetAllForSentMessages(x => x.From == authorMail);
            return View(sentMessages);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var message = _messageService.GetById(id);
            message.isSeen = true;
            _messageService.Update(message);
            return View(message);
        }

        public ActionResult GetSentMessageDetails(int id)
        {
            var values = _messageService.GetById(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult GetDraftMessages()
        {
            string authorMail = (string)Session["AuthorMail"];
            var draftMessages = _messageService.GetAll(x => x.isDraft == true & x.From == authorMail);
            return View(draftMessages);
        }

        [HttpGet]
        public ActionResult GetNotSeenMessages()
        {
            string authorMail = (string)Session["AuthorMail"];
            var notSeenMessages = _messageService.GetAll(x => x.isSeen == false & x.To==authorMail );
            return View(notSeenMessages);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();

        }

        [HttpPost]
        public ActionResult AddDraftMessageOrSendMessage(Message message)
        {
            string authorMail = (string)Session["AuthorMail"];
            if (Request["Send"] != null)
            {
                Message sentMessage = new Message
                {
                    Content = message.Content,
                    Date = message.Date,
                    isDraft = message.isDraft,
                    From = authorMail,
                    Subject = message.Subject,
                    To = message.To
                };

                ValidationResult results = validationRules.Validate(sentMessage);

                if (results.IsValid)
                {

                    _messageService.Add(sentMessage);

                    return RedirectToAction("SentMessages");
                }

                else
                {
                    foreach (var error in results.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }

                    return View("NewMessage");
                }

            }

            else if (Request["Draft"] != null)
            {

                Message draftMessage = new Message
                {
                    Date = message.Date,
                    Content = message.Content,
                    From = authorMail,
                    Subject = message.Subject,
                    To = message.To,
                    isDraft = true

                };
                _messageService.Add(draftMessage);

                return RedirectToAction("GetDraftMessages");

            }

            return View();

        }

        public PartialViewResult MessageListMenu()
        {
            string authorMail = (string)Session["AuthorMail"];
            ViewBag.NotSeen = _messageService.Count(x => x.isSeen == false & x.To==authorMail);
            ViewBag.MessageCount = _messageService.Count(x => x.To == authorMail & x.isSeen==false);
            ViewBag.SentMessagesCount = _messageService.Count(x => x.From == authorMail);
            ViewBag.DraftMessagesCount = _messageService.Count(x => x.isDraft == true & x.From == authorMail);
            return PartialView();
        }
    }
}