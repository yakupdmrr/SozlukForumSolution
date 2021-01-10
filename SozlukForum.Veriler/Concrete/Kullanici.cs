using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Abstracts;

namespace SozlukForum.Veriler.Concrete
{
    public class Kullanici : INesne
    {
        public int KullaniciId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Eposta { get; set; }
        public string Parola { get; set; }
        public bool Yetki { get; set; }

        public List<int> TakipEttikleri { get; set; }
        public List<int> TakipEdildikleri { get; set; }

    }
}
