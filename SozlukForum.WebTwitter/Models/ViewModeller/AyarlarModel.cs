using SozlukForum.Veriler.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SozlukForum.WebTwitter.Models.ViewModeller
{
    public class AyarlarModel
    {
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }
        public HttpPostedFileBase ProFilResmi { get; set; }
        public int ResimId { get; set; }
        public string ResimYolu { get; set; }
        public string ResimAdi { get; set; }
    }
}