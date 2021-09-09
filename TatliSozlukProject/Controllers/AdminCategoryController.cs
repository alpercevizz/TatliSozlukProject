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
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        // GET: AdminCategory

        [Authorize(Roles = "B")] // sadece B rolündeki kişiler bu sayfayı görsün.
        public ActionResult Index()
        {
            var categoryList = cm.GetCatList();
            return View(categoryList);
        }

        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(Category cat)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(cat);

            if(results.IsValid)
            {
                cm.AddCategory(cat);
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

        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = cm.GetById(id);
            cm.CategoryDelete(categoryValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {

            // Güncellenecek olan kategoriyi bul.
            var catValue = cm.GetById(id); // id'ye göre gelen valueları değişkene atadık.
            return View(catValue);


        }

        [HttpPost]
        public ActionResult EditCategory(Category cat)
        {
            cm.CategoryUpdate(cat);
            return RedirectToAction("Index");


        }

    }
}