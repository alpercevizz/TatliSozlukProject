using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace TatliSozlukProject.Controllers
{
    public class AuthorPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        AuthorManager authorManager = new AuthorManager(new EfAuthorDal());
        AuthorValidator validationRules = new AuthorValidator();
        Context c = new Context();

        [HttpGet]
        public ActionResult AuthorProfile()
        {
            string p = (string)Session["AuthorMail"];
            var getAuthor = c.Authors.Where(x => x.AuthorMail == p).Select(y => y.AuthorID).FirstOrDefault();
            int id = getAuthor;
            var authorVal = authorManager.GetById(id);
            return View(authorVal);
        }

        [HttpPost]
        public ActionResult AuthorProfile(Author author)
        {

            ValidationResult results = validationRules.Validate(author);
            if (results.IsValid)
            {
                authorManager.UpdateAuthor(author);
                return RedirectToAction("AllHeading", "AuthorPanel");
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

        public ActionResult MyHeading(string p)
        {
            
            p = (string)Session["AuthorMail"];
            var authorIDInfo = c.Authors.Where(x => x.AuthorMail == p).Select(y => y.AuthorID).FirstOrDefault();
            var myHeading = hm.GetHeadingListByAuthor(authorIDInfo);
            return View(myHeading);
        }

        [HttpGet]
        public ActionResult CreateHeading()
        {

            List<SelectListItem> Categories = (from x in cm.GetCatList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString(),
                                               }).ToList();
            ViewBag.valueCat = Categories;
            return View();
        }

        [HttpPost]
        public ActionResult CreateHeading(Heading heading)
        {
            string value = (string)Session["AuthorMail"];
            var authorIDInfo = c.Authors.Where(x => x.AuthorMail == value).Select(y => y.AuthorID).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.AuthorID = authorIDInfo;
            heading.HeadingStatus = true;
            hm.AddHeading(heading);
            return RedirectToAction("MyHeading");
           
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
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValues = hm.GetById(id);
            headingValues.HeadingStatus = false;
            hm.DeleteHeading(headingValues);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int page = 1)
        {

            var headings = hm.GetHeadingList().ToPagedList(page,4);
            return View(headings);
        }
    }
}