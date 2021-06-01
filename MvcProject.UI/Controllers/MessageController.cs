using BusinessLayer.Abstract;
using EntityLayer.Concrete;
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

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public ActionResult Inbox()
        {
            var messages = _messageService.GetAllForInbox();
            return View(messages);
        }

        public ActionResult SentMessages()
        {
            var sentMessages = _messageService.GetAllForSentMessages();
            return View(sentMessages);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            _messageService.Add(message);
            return RedirectToAction("SentMessages");
        }
    }
}