using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Abstracts;

namespace SozlukForum.Veriler.Concrete
{
    public class Yorum: Etkilesim,INesne
    {
        public string YorumId { get; set; }
        public int KullaniciId { get; set; }
        public string YapilmaZamani{ get; set; }
        public int YorumTipi { get; set; }
    }
}
