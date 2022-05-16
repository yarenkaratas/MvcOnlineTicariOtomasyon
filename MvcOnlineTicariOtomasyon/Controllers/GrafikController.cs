using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori- Ürün Stok Sayısı").AddLegend("Stok").AddSeries
                ("Değerler", xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" }, 
                yValues: new[] { 85, 66, 98 }).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }


        Context c = new Context();
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = c.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stok));
            var grafik = new Chart(width: 800, height: 800)
                .AddTitle("Stoklar")
                .AddSeries(chartType: "Column", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(grafik.ToWebImage().GetBytes(), "Image/jpeg");
            //column yazan yere piefalan diyerek farklı şek.de getirebilisin 
        }


        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(Urunlistesi(), JsonRequestBehavior.AllowGet);
        }// visulize görselleştir anlamında genelde kullanılıyor
        public List<sinif1> Urunlistesi()
        {
            List<sinif1> snf = new List<sinif1>();
            snf.Add(new sinif1()
            {
                urunad = "Bilgisayar",
                stoksayısı = 120
            });
            snf.Add(new sinif1()
            {
                urunad = "Beyaz Eşya",
                stoksayısı = 150
            });
            snf.Add(new sinif1()
            {
                urunad = "Mobilya",
                stoksayısı = 70
            });
            snf.Add(new sinif1()
            {
                urunad = "Küçük Ev Aletleri",
                stoksayısı = 180
            });
            snf.Add(new sinif1()
            {
                urunad = "Mobil Cihazlar",
                stoksayısı = 90
            });
            return snf;
        }




        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult2()
        {
            return Json(Urunlistesi2(), JsonRequestBehavior.AllowGet);
        }

        public List<sinif2>Urunlistesi2()
        {
            List<sinif2> snf=new List<sinif2>();
            using (var c = new Context())
            {
                snf=c.Uruns.Select(x=> new sinif2
                {
                    urn=x.UrunAd,
                    stk=x.Stok
                }).ToList();
            }
            return snf;
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }
}
