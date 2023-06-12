using System.Linq;
using System.Web.Mvc;
using mvcStok._1.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace mvcStok._1.Controllers
{
    public class kategoriController : Controller
    {
        // GET: kategori
        dbmvcstokEntities1 db = new dbmvcstokEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult katagoriler()
        {
            var degerler = db.tblKategoriler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult ekle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ekle(tblKategoriler p1)
        {
            if(!ModelState.IsValid)
            {
                return View("ekle");
            }
            var degerler = p1;
            degerler.kategoriad = degerler.kategoriad.ToUpper();
            db.tblKategoriler.Add(degerler);
            db.SaveChanges();
            return RedirectToAction("katagoriler");
        }

        public ActionResult sil(int id)
        {
            var kategori = db.tblKategoriler.Find(id);
            db.tblKategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("katagoriler");
        }

        public ActionResult guncelle(int id)
        {
            var ktgr = db.tblKategoriler.Find(id);
            return View(ktgr);
        }
        public ActionResult gnc(tblKategoriler getir)
        {
            
            var veri = db.tblKategoriler.Find(getir.kategoriid);
            veri.kategoriad = getir.kategoriad;
            db.SaveChanges();
            return RedirectToAction("katagoriler");
        }
        
    }
}