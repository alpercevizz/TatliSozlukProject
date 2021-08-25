using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    public class AuthorController : Controller
    {
        AuthorManager am = new AuthorManager(new EfAuthorDal());
        AuthorValidator validationRules = new AuthorValidator();
        public ActionResult Index()
        {
            var authorValues = am.GetAuthorList();
            return View(authorValues);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(Author author)
        {
            ValidationResult results = validationRules.Validate(author);
            if(results.IsValid)
            {
                am.AddAuthor(author);
                return RedirectToAction("Index");
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
        [HttpGet]
        public ActionResult EditAuthor(int id)
        {
            var authorValue = am.GetById(id);
            return View(authorValue);
        }
        [HttpPost]
        public ActionResult EditAuthor(Author author)
        {

            ValidationResult results = validationRules.Validate(author);
            if (results.IsValid)
            {
                am.UpdateAuthor(author);
                return RedirectToAction("Index");
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
    }
}