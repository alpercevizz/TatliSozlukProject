using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TatliSozlukProject.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        AuthorManager am = new AuthorManager(new EfAuthorDal());
        public ActionResult Index()
        {
            var headingValues = hm.GetHeadingList();
            return View(headingValues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> Categories = (from x in cm.GetCatList()
                                               select new SelectListItem
                                               {
                                                   Text=x.CategoryName,
                                                   Value = x.CategoryID.ToString(),
                                               }).ToList();
            

            List<SelectListItem> AuthorVal = (from x in am.GetAuthorList()
                                              select new SelectListItem
                                              {
                                                  Text = x.AuthorName + " " + x.AuthorSurname,
                                                  Value = x.AuthorID.ToString(),
                                              }).ToList();
            ViewBag.valueCat = Categories;
            ViewBag.valueAuthor = AuthorVal;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.AddHeading(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> Categories = (from x in cm.GetCatList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString(),
                                               }).ToList();
            ViewBag.valueCat = Categories;
            var headingVal = hm.GetById(id);
            return View(headingVal);
        }


        [HttpPost]

        public ActionResult EditHeading(Heading heading)
        {
            hm.UpdateHeading(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValues = hm.GetById(id);
            headingValues.HeadingStatus = false;
            hm.DeleteHeading(headingValues);
            return RedirectToAction("Index");
        }

    }
}