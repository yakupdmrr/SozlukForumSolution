using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Abstracts;

namespace SozlukForum.Veriler.Concrete
{
    public class Resim:INesne
    {
        public int ResimId { get; set; }
        public string ResimYolu { get; set; }
        public string ResimAdi { get; set; }

    }
}
