using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogSite.DB;

namespace BlogSite.Controllers
{
    public class HomeController : Controller
    {
        BlogSiteEntities1 entity = new BlogSiteEntities1();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult CategoryWidgetGet()
        {
            var kat = entity.Kategoris.ToList();
            return View(kat);
        }

        public ActionResult PostWidgetGet()
        {
            ViewBag.Fresh = entity.Makales.OrderByDescending(x => x.YayimTarihi).Take(5);
            ViewBag.Populer = entity.Makales.OrderByDescending(x => x.Goruntulenme).Take(5);
            return View();
        }

        public ActionResult TagsWidgetGet()
        {
            var tag = entity.Etikets.ToList();
            return View(tag);
        }

       public ActionResult AllMakaleGet()
        {
            var makale = entity.Makales.ToList();
            return View("MakaleListele",makale);
        }

    }
}