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
    public class MessageController : Controller
    {
        IMessageService _messageService;
        MessageValidator validationRules = new MessageValidator();

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public ActionResult Inbox()
        {
            string userName = (string)Session["UserName"];
            var messages = _messageService.GetAllForInbox(x=>x.To==userName);
            return View(messages);
        }

        public ActionResult SentMessages()
        {
            string userName = (string)Session["UserName"];
            var sentMessages = _messageService.GetAllForSentMessages(x=>x.From== userName);
            return View(sentMessages);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {           
                return View();
           
        }

        //[HttpPost]
        //public ActionResult NewMessage(Message message)
        //{

        //    ValidationResult results = validationRules.Validate(message);

        //    if (results.IsValid)
        //    {
        //        _messageService.Add(message);
                
        //        return RedirectToAction("SentMessages");
        //    }

        //    else
        //    {
        //        foreach (var error in results.Errors)
        //        {
        //            ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
        //        }

        //        return View();
        //    }
           
        //}

        [HttpGet]
        public ActionResult GetDraftMessages()
        {
            string userName = (string)Session["UserName"];
            var draftMessages = _messageService.GetAll(x => x.isDraft == true & x.From == userName);
            return View(draftMessages);
        }

        [HttpGet]
        public ActionResult GetNotSeenMessages()
        {
            string userName = (string)Session["UserName"];
            var notSeenMessages = _messageService.GetAll(x => x.isSeen == false & x.To == userName);
            return View(notSeenMessages);
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

        [HttpPost]
        public ActionResult AddDraftMessageOrSendMessage(Message message)
        {
            string userName = (string)Session["UserName"];
            if (Request["Send"] != null)
            {
                Message sentMessage = new Message
                {
                    Content = message.Content,
                    Date = message.Date,
                    isDraft = message.isDraft,
                    From = userName,
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
       
            else if (Request["Draft"]!=null)
            {

                Message draftMessage = new Message
                {
                    Date = message.Date,
                    Content = message.Content,
                    From = userName,
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
            string userName = (string)Session["UserName"];
            ViewBag.NotSeen = _messageService.Count(x => x.isSeen == false & x.To==userName);
            ViewBag.MessageCount = _messageService.Count(x => x.To == userName & x.isSeen == false);
            ViewBag.SentMessagesCount = _messageService.Count(x => x.From == userName);
            ViewBag.DraftMessagesCount = _messageService.Count(x => x.isDraft == true & x.From == userName);
            return PartialView();
        }
    }
}