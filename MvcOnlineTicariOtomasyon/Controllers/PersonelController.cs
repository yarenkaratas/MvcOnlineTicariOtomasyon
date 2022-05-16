using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            //List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
            //                               select new SelectListItem
            //                               {
            //                                   Text = x.DepartmanAd,
            //                                   Value = x.DepartmanID.ToString()
            //                               }).ToList();
            //ViewBag.dgr1 = deger1;  
            return View();
        }
        //[HttpGet]
        //public ActionResult PersonelEkle()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult PersonelEkle(Personel p)
        //{
        //    c.Personels.Add(p);
        //    c.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        //public ActionResult PersonelGetir(int id)
        //{
        //    List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
        //                                   select new SelectListItem
        //                                   {
        //                                       Text = x.DepartmanAd,
        //                                       Value = x.DepartmanID.ToString()
        //                                   }).ToList();
        //    ViewBag.dgr1 = deger1;
        //    var prs = c.Personels.Find(id);
        //    return View("PersonelGetir",prs);
        //}
        //public ActionResult PersonelGuncelle(Personel p)
        //{
        //    var prsn = c.Personels.Find(p.PersonelID);
        //    prsn.PersonelAd= p.PersonelAd;
        //    prsn.PersonelSoyad= p.PersonelSoyad;
        //    prsn.PersonelGorsel= p.PersonelGorsel;
        //    prsn.DepartmanID= p.DepartmanID;
        //    c.SaveChanges();
        //    return View("Index");
        //}
    }
}