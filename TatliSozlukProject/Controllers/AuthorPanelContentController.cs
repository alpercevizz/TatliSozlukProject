using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TatliSozlukProject.Controllers
{
    public class AuthorPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context c = new Context();
        public ActionResult MyContent(string p)
        {
           
            p = (string)Session["AuthorMail"];
            // sisteme giriş yapılan mailin id'sini al.
            var authorIDInfo = c.Authors.Where(x => x.AuthorMail == p).Select(y => y.AuthorID).FirstOrDefault();
            var contentValues = contentManager.GetContentByAuthor(authorIDInfo);
            return View(contentValues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["AuthorMail"];
            // sisteme giriş yapılan mailin id'sini al.
            var authorIDInfo = c.Authors.Where(x => x.AuthorMail == mail).Select(y => y.AuthorID).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
            content.AuthorID = authorIDInfo;
            content.ContentStatus = true;
            contentManager.AddContent(content);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}