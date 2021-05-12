using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.UI.Controllers
{
    public class StatisticController : Controller
    {

        ICategoryService _categoryService;
        IContentService _contentService;
        IAboutService _aboutService;
        IAuthorService _authorService;
        IContactService _contactService;
        ITitleService _titleService;

        public StatisticController(ICategoryService categoryService,
            IContentService contentService, IAboutService aboutService,
            IAuthorService authorService, IContactService contactService,
            ITitleService titleService)
        {
            _categoryService = categoryService;
            _contentService = contentService;
            _aboutService = aboutService;
            _authorService = authorService;
            _contactService = contactService;
            _titleService = titleService;
        }




        // GET: Statistic
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calculate()
        {

            ViewBag.CategoryCount = _categoryService.Count();
            ViewBag.TitleinYazilimCategory = _titleService.Count(t => t.Id == 6); //Kategorisi "Yazılım" olan başlıkların sayısı.
            ViewBag.AuthorWithALetter = _authorService.GetAll().Where(a=>a.Name.Contains('a')).ToList().Count; // İsminde a harfi bulunan yazarların sayısı            
            ViewBag.CategoryHasMostTitle = _titleService.GetCategoryDetails().GroupBy(x => x.CategoryName).
                Select(grp => new { CategoryName = grp.Key, Count = grp.Count() }).
                OrderByDescending(x => x.Count).FirstOrDefault().CategoryName; // En çok Başlığa sahip kategori sayısı
            ViewBag.DifferanceBetweenStatusTrueAndFalse = 
                _categoryService.GetAll(x => x.Status == true).Count - 
                _categoryService.GetAll(x => x.Status == false).Count;  //Aktif olan kategoriler ile pasif olan kategorilerin farkı


         


            return View();
        }
    }
}