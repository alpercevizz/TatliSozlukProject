using DataAccessLayer.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TatliSozlukProject.Controllers
{
    public class LoginController : Controller
    {
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
    }
}