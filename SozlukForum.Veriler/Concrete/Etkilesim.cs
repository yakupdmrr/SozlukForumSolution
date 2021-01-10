using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Abstracts;

namespace SozlukForum.Veriler.Concrete
{
    public class Etkilesim : INesne
    {
        public int EtkilesimId { get; set; }
        public string PaylasimId { get; set; }
    }
}
