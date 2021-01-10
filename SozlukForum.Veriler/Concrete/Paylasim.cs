using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Abstracts;

namespace SozlukForum.Veriler.Concrete
{
    public class Paylasim : INesne
    {
        public string PaylasimId { get; set; }
        public int KategoriId { get; set; }
        public int KullaniciId { get; set; }
        public int PaylasimTipi { get; set; }
        public string GirilmeZamani { get; set; }
    }
}
