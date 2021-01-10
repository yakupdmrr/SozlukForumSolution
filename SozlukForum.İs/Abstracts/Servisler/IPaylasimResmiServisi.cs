using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.İs.Abstracts
{
    public interface IPaylasimResmiServisi
    {
        void Ekle(PaylasimResmi veri);
        void Sil(PaylasimResmi veri);
        void Guncelle(PaylasimResmi veri);
        List<PaylasimResmi> IstekGetir(string paylasimId);
        List<PaylasimResmi> HepsiniGetir();
    }
}
