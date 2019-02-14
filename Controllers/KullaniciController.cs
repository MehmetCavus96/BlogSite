using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogSite.DB;

namespace BlogSite.Controllers
{
    public class KullaniciController : Controller
    {
        BlogSiteEntities1 entity = new BlogSiteEntities1();

        // GET: Kullanici
        public ActionResult Index(Guid id)
        {
            return View(id);
        }

        public ActionResult MakaleListele(Guid id)
        {
            var data = entity.Makales.Where(x => x.YazarID == id);
            return View("MakaleListele",data);
        }

    }
}