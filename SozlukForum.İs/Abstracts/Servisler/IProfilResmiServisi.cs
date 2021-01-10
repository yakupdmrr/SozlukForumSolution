using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.İs.Abstracts
{
    public interface IProfilResmiServisi
    {
        void Ekle(ProfilResmi veri);
        void Sil(ProfilResmi veri);
        void Guncelle(ProfilResmi veri);
        ProfilResmi IstekGetir(int kullaniciId);
        
    }
}
