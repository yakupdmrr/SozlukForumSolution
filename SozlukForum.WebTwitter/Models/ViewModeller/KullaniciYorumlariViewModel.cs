using SozlukForum.Veriler.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SozlukForum.WebTwitter.Models.ViewModeller
{
    public class KullaniciYorumlariViewModel
    {
        public Kullanici Kullanici { get; set; }
        public string YorumId { get; set; }
        public YorumMetni YorumMetni { get; set; }
        public List<YorumResmi> YorumResimleri { get; set; }
        public ProfilResmi ProfilResmi { get; set; }
        public string YapilmaZamani { get; set; }
        
    }
}