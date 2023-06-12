using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcStok._1.Models.Entity;

namespace mvcStok._1.Controllers
{
    public class musterilerController : Controller
    {
        dbmvcstokEntities1 db = new dbmvcstokEntities1();
        // GET: musteriler
        public ActionResult musteriler()
        {
            var degerler = db.tblMusteriler.ToList();
            return View(degerler);
        }
        public ActionResult sil(int id)
        {
            var musteri = db.tblMusteriler.Find(id);
            db.tblMusteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("musteriler");
        }
        
        [HttpGet]
        public ActionResult ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ekle(tblMusteriler veri)
        {
            if(!ModelState.IsValid)
            {
                return View("ekle");
            }
            veri.musteriad=veri.musteriad.ToUpper();
            veri.musterisoyad = veri.musterisoyad.ToUpper();
            db.tblMusteriler.Add(veri);
            db.SaveChanges();
            return RedirectToAction("musteriler");
        }
        public ActionResult guncelle(int id)
        {
            var musteri = db.tblMusteriler.Find(id);
            return View(musteri);
        }
        public ActionResult gnc(tblMusteriler getir)
        {
            var musteri = db.tblMusteriler.Find(getir.musteriid);
            musteri.musteriad=getir.musteriad.ToUpper();
            musteri.musterisoyad = getir.musterisoyad.ToUpper();    
            db.SaveChanges();
            return RedirectToAction("musteriler");
        }
    }
}