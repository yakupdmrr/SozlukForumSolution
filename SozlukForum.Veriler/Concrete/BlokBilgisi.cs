using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Abstracts;

namespace SozlukForum.Veriler.Concrete
{
   public class BlokBilgisi:INesne
    {
        public int BlokBilgiId { get; set; }
        public int BlokPaylasimId { get; set; }
        public int KullaniciId { get; set; }

    }
}
