using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Abstracts;

namespace SozlukForum.Veriler.Concrete
{
    public class RaporBilgisi : INesne
    {
        public int RaporBilgid { get; set; }
        public int RaporId { get; set; }
        public int KullaniciId{ get; set; }

    }
}
