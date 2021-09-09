using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TatliSozlukProject.Controllers
{
    public class AuthorPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator msjValid = new MessageValidator();
       

        public ActionResult Inbox()
        {
            string mail = (string)Session["AuthorMail"];
            var messageValue = mm.GetMessageListInbox(mail);
            return View(messageValue);
        }

        public ActionResult Sendbox()
        {
            string mail = (string)Session["AuthorMail"];
            var mesValue = mm.GetMessageListSendbox(mail);
            return View(mesValue);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {

            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            string sender = (string)Session["AuthorMail"];
            ValidationResult results = msjValid.Validate(message);
            if (results.IsValid)
            {
                message.SenderMail = sender;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.AddMessage(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public PartialViewResult MessageSidebar()
        {
            return PartialView();
        }

        public ActionResult GetMessageListTrash()
        {
            var messageListToTrash = mm.GetMessageListTrash();
            return View(messageListToTrash);
        }

        public ActionResult GetMessageListDrafts()
        {
            var messageListToDrafts = mm.GetMessageListDrafts();
            return View(messageListToDrafts);
        }
    }
}