using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TatliSozlukProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AuthorLoginManager alm = new AuthorLoginManager(new EfAuthorDal());

        [HttpGet]
        public ActionResult Index()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            Context c = new Context();
            var adminUserInfo = c.Admins.FirstOrDefault(x => x.AdminUsername == admin.AdminUsername && x.AdminPassword == admin.AdminPassword);
            if(adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUsername, false);
                Session["AdminUsername"] = adminUserInfo.AdminUsername;
                return RedirectToAction("Index", "AdminCategory");
            }

            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }

       [HttpPost]
        public ActionResult AuthorLogin(Author author)
        {
            Context c = new Context();
            //var authorUserInfo = c.Authors.FirstOrDefault(x => x.AuthorMail == author.AuthorMail && x.AuthorPassword == author.AuthorPassword);
            var authorUserInfo = alm.GetAuthor(author.AuthorMail,author.AuthorPassword);
            if (authorUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(authorUserInfo.AuthorMail, false);
                Session["AuthorMail"] = authorUserInfo.AuthorMail;
                return RedirectToAction("MyContent", "AuthorPanelContent");
            }

            else
            {
                return RedirectToAction("AuthorLogin");
            }
           
            
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}