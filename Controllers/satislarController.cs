using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcStok._1.Models.Entity;

namespace mvcStok._1.Controllers
{
    
    public class satislarController : Controller
    {
        dbmvcstokEntities1 db = new dbmvcstokEntities1();

        public ActionResult satislar()
        {
            var degerler = db.tblSatis.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult ekle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ekle(tblSatis p)
        {
            db.tblSatis.Add(p);
            db.SaveChanges();
            return RedirectToAction("satislar");
        }

        public ActionResult sil(int id)
        {
            var veri = db.tblSatis.Find(id);
            db.tblSatis.Remove(veri);
            db.SaveChanges();
            return RedirectToAction("satislar");
        }
        public ActionResult guncelle(int id)
        {
            var veri = db.tblSatis.Find(id);
            return View(veri);
        }
        public ActionResult gnc(tblSatis p1)
        {
            var veri = db.tblSatis.Find(p1.satisid);
            veri.musteri = p1.musteri;
            veri.adet = p1.adet;    
            veri.fiyat = p1.fiyat;
            veri.urun = p1.urun;
            db.SaveChanges();
            return RedirectToAction("satislar");
        }
    }
}