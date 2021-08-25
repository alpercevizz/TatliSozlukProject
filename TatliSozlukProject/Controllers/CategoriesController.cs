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
    public class CategoriesController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetCategoryList()
        {
            var categoryValues = cm.GetCatList();
            return View(categoryValues);
        }

        [HttpGet] // sayfa yüklendiğinde.
        public ActionResult AddNewCategory()
        {
            return View();
        }

        [HttpPost] // butona tıklandığında.
        public ActionResult AddNewCategory(Category cat)
        {
            // entityden türettiğimiz sınıfı parametre olarak çağırdık.
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(cat); // categoryValidator sınıfında olan değerlere göre parametreden gelen değerin doğruluğuna bakar. 
            if(results.IsValid)
            {
                cm.AddCategory(cat); // result validate edildi mi ? 
                return RedirectToAction("GetCategoryList");
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