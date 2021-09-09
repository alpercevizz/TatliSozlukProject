using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TatliSozlukProject.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator contactValidator = new ContactValidator();

        
        public ActionResult Index()
        {
            var contactValues = contactManager.GetContactList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = contactManager.GetById(id);
            return View(contactValues);
        }

        public PartialViewResult MessageSidebar()
        {
            string userSession = (string)Session["AuthorMail"];
            var contactNum = contactManager.GetContactList();
            ViewBag.num = contactNum.Count();

            var inboxNum = mm.GetMessageListInbox(userSession);
            ViewBag.value1 = inboxNum.Count();

            var sendboxNum = mm.GetMessageListSendbox(userSession);
            ViewBag.value2 = sendboxNum.Count();

            var draftsNum = mm.GetMessageListDrafts();
            ViewBag.value3 = draftsNum.Count();

            var trashesNum = mm.GetMessageListTrash();
            ViewBag.value4 = trashesNum.Count();

            return PartialView();
        }
    }
}