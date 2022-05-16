using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var k = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(y => y.TakipKodu.Contains(p)); // contains değil where yazıp direkt o kadu da çağırırsın içinde a olanlar falan yerine
            }
            return View(k.ToList());  // Kargo takip numarasına göre arama burada yapıldı
            //var kargolar = c.KargoDetays.ToList();
            //return View(kargolar);
        }
        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D","E","F" };
            int k1, k2, k3;
            k1 = rnd.Next(0, karakterler.Length);//(0, 4)
            k2 = rnd.Next(0, karakterler.Length);
            k3 = rnd.Next(0, karakterler.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000); //10-->3 1 2 1 2 1
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod=s1.ToString()+karakterler[k1]+s2+karakterler[k2]+s3+karakterler[k3];
            ViewBag.takipkod = kod;
            return View();
        }
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay d)
        {
            c.KargoDetays.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KargoTakip(string id)
        {
            //p = "abc123as"; global asax tan routeconfig te id ye göre geldiği için alındığı için p parameters yerine id kullandı
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            
            return View(degerler);
        }
    }
}