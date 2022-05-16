using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Class3
    {
        public IEnumerable<SelectListItem>  Kategoriler { get; set; } //Liste formatında olacağı için ıenumarable
        public IEnumerable<SelectListItem>  Urunler { get; set; }
    }
}