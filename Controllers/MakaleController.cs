using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogSite.DB;

namespace BlogSite.Controllers
{
    public class MakaleController : Controller
    {
        BlogSiteEntities1 entity = new BlogSiteEntities1();

        // GET: Makale
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TariheGoreListele(int yil, int ay)
        {
            ViewBag.yil = yil;
            ViewBag.ay = ay;
            return View();
        }

        public ActionResult MakaleListele(int yil, int ay)
        {
            var data = entity.Makales.Where(x => x.YayimTarihi.Year == yil && x.YayimTarihi.Month == ay);
            return View("MakaleListele",data);
        }

        public ActionResult Detay(int id)
        {
           
            ViewBag.Kullanici = Session["Kullanici"];
       
            Makale mk = entity.Makales.FirstOrDefault(x => x.ID == id);
            return View(mk);
        }

        [HttpPost]
        public ActionResult YorumYaz(Yorum yorum)
        {
            yorum.EklenmeTarihi = DateTime.Now;
            yorum.Baslik = "";
            entity.Yorums.Add(yorum);
            entity.SaveChanges();
            return RedirectToAction("Detay", new {id=yorum.MakaleID });
        }

    }
}