using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.İs.Abstracts.Servisler
{
    public interface IPaylasimMetniServisi
    {
        void Ekle(PaylasimMetni veri);
        void Sil(PaylasimMetni veri);
        void Guncelle(PaylasimMetni veri);
        PaylasimMetni IstekGetir(string paylasimId);
        List<PaylasimMetni> HepsiniGetir();
    }
}
