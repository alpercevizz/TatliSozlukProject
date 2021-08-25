using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TatliSozlukProject.Controllers
{
    public class IstatistikController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        AuthorManager am = new AuthorManager(new EfAuthorDal());
        public ActionResult Index()
        {
            ViewBag.Value1 = cm.GetCatList().Count(); // Toplam kategori sayısı
            ViewBag.Value2 = hm.GetHeadingList().Where(x => x.HeadingId == 6).Count(); // Yazılım kategorisindeki toplam başlık sayısı
            ViewBag.Value3 = am.GetAuthorList().Where(x => x.AuthorName.Contains("a") || x.AuthorName.Contains("A")).Count(); // Yazar adında a harfi geçen yazar sayısı
            ViewBag.Value4 = cm.GetCatList().Where(x => x.CategoryID == (hm.GetHeadingList().GroupBy(h => h.CategoryID).OrderByDescending(z => z.Count()).Select(y => y.Key)
                             .FirstOrDefault())).Select(k => k.CategoryName).FirstOrDefault(); // En fazla başlığa sahip kategori adı.
            ViewBag.Value5 = cm.GetCatList().Where(x => x.CategoryStatus == true).Count(); // Kategori tablosunda durumu aktif olan kategori sayısı
            ViewBag.Value6 = cm.GetCatList().Where(x => x.CategoryStatus == false).Count(); // Kategori tablosunda durumu pasif olan kategori sayısı

            return View();
        }
    }
}