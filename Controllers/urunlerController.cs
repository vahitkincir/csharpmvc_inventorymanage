using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcStok._1.Models.Entity;

namespace mvcStok._1.Controllers
{

    public class urunlerController : Controller
    {
        dbmvcstokEntities1 db = new dbmvcstokEntities1();
        // GET: urunler
        public ActionResult urunler()
        {
            var degerler = db.tblUrunler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult ekle()
        {
            List<SelectListItem> degerler = (from i in db.tblKategoriler
                                      select new SelectListItem
                                      {
                                            Text = i.kategoriad,
                                            Value = i.kategoriid.ToString()
                                      }).ToList();
            ViewBag.deger = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult ekle(tblUrunler p1)
        {
            var kategori = db.tblKategoriler.Where(m=> m.kategoriid == p1.tblKategoriler.kategoriid).FirstOrDefault();
            
            p1.tblKategoriler = kategori;

            db.tblUrunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("urunler");
        }
        public ActionResult sil(int id)
        {
            var urun = db.tblUrunler.Find(id);
            db.tblUrunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("urunler");
        }
        public ActionResult guncelle(int id)
        {
            var bul = db.tblUrunler.Find(id);
            List<SelectListItem> degerler = (from m in db.tblKategoriler
                                             select new SelectListItem
                                             {
                                                 Text = m.kategoriad,
                                                 Value = m.kategoriid.ToString()
                                             }).ToList();
            ViewBag.deger = degerler.ToList();
            return View(bul);
        }
        public ActionResult gnc(tblUrunler getir)
        {
            var veri = db.tblUrunler.Find(getir.urunid);
            veri.urunad=getir.urunad.ToUpper();
            veri.marka=getir.marka.ToUpper();
            veri.urunkategori = getir.urunkategori.Value;
            veri.fiyat = getir.fiyat;
            veri.stok = getir.stok;
            db.SaveChanges();
            return RedirectToAction("urunler");
        }

    }
}