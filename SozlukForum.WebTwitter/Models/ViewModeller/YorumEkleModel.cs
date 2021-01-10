using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SozlukForum.WebTwitter.Models.ViewModeller
{
    public class YorumEkleModel
    {
        public string YorumMetni { get; set; }
        public HttpPostedFileBase[] YorumResimleri { get; set; }
        public string PaylasimId { get; set; }
    }
}