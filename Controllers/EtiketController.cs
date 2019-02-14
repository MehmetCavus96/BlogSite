using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogSite.DB;

namespace BlogSite.Controllers
{
    public class EtiketController : Controller
    {
        BlogSiteEntities1 entity = new BlogSiteEntities1();

        // GET: Etiket
        public ActionResult Index(int id)
        {
            return View(id);
        }

        public ActionResult MakaleListele(int id)
        {
            var data = entity.Makales.Where(x => x.Etikets.Any(me => me.ID == id));
            return View("MakaleListele",data);
        }
    }
}