using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TatliSozlukProject.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string searchValue)
        {
            var values = contentManager.GetContentList(searchValue);
            
            return View(values);
        }
        public ActionResult GetContentByHeading(int id)
        {
            var contentValues = contentManager.GetContentByHeadingId(id);
            return View(contentValues);
        }
    }

}