using SozlukForum.Veriler.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SozlukForum.WebTwitter.Models.ViewModeller
{
    public class TekPaylasimViewModel
    {
        public Kullanici Kullanici { get; set; }
        public string PaylasimId { get; set; }
        public PaylasimMetni PaylasimMetni { get; set; }
        public List<PaylasimResmi> PaylasimResimleri { get; set; }
        public ProfilResmi ProfilResmi { get; set; }
        public List<EtkilesimLike> EtkilesimLikelar { get; set; }
        public List<EtkilesimDislike> EtkilesimDislikelar { get; set; }
        public List<Yorum> Yorumlar { get; set; }
      //  public Kategori Kategori { get; set; }
        public string GirilmeZamani { get; set; }
    }
}