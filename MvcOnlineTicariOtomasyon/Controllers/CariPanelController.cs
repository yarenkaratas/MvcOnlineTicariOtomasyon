using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel


        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.Mesajlars.Where(x => x.Alıcı == mail).ToList();
            ViewBag.m = mail;
            var mailid=c.Carilers.Where(x=>x.CariMail==mail).Select(y=>y.CariID).ToString().FirstOrDefault();
            ViewBag.mid = mailid;
            var toplamsatis=c.SatisHarekets.Where(x=>x.CariID==mailid).Count();
            ViewBag.toplamsatis=toplamsatis;
            var toplamtutar=c.SatisHarekets.Where(x=>x.CariID!=mailid).Sum(y=>y.ToplamTutar);
            ViewBag.toplamtutar = toplamtutar;
            var adsoyad = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;  

            return View(degerler);
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.CariID == id).ToList();
            return View(degerler);
        }

        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Alıcı == mail).OrderByDescending(x => x.MsajID).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Gönderici == mail).OrderByDescending(z => z.MsajID).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Mesajlars.Where(x => x.MsajID == id).ToList();
            var mail = (string)Session["CariMail"];
            var gelensayisi = c.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var gelensayisi = c.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidensayisi;

            return View();
        }
        [HttpPost]
        public ActionResult YeniMesajlar(Mesajlar m)
        {
            var mail = (string)Session["CariMail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gönderici = mail;
            c.Mesajlars.Add(m);
            c.SaveChanges();
            return View();
        }
        public ActionResult KargoTakip(string p)
        {
            var k = from x in c.KargoDetays select x;
            k = k.Where(y => y.TakipKodu.Contains(p)); // contains değil where yazıp direkt o kadu da çağırırsın içinde a olanlar falan yerine
            return View(k.ToList());

        }
        public ActionResult CariKargoTakip(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();

            return View(degerler);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();// İstekleri terket 
            return RedirectToAction("Index", "Login");

        }
        public PartialViewResult Partial1()
        {
            var mail = (string)Session["CariMail"];
            var id=c.Carilers.Where(x=>x.CariMail == mail).Select(y=>y.CariID).FirstOrDefault();
            var caribul = c.Carilers.Find(id);
            return PartialView("Partial1", caribul);
        }
        public PartialViewResult Partial2()
        {
            var veriler=c.Mesajlars.Where(x=>x.Gönderici == "admin").ToList();
            return PartialView(veriler);
        }
        public ActionResult CariBilgiGuncelle(Cariler cr)
        {
            var cari=c.Carilers.Find(cr.CariID);
            cari.CariAd=cr.CariAd;
            cari.CariSoyad=cr.CariSoyad;
            cari.CariSifre=cr.CariSifre;
            return RedirectToAction("Index");
        }


    }
}