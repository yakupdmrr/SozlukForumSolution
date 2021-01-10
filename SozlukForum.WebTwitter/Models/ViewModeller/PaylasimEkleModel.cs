using SozlukForum.Veriler.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SozlukForum.WebTwitter.Models.ViewModeller
{
    public class PaylasimEkleModel
    {
        public string PaylasimMetni { get; set; }
        public HttpPostedFileBase[] PaylasimResimleri { get; set; }
        public string KategoriAdi { get; set; }
    }
}