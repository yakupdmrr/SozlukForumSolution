using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.İs.Abstracts
{
    public interface IKullaniciServisi
    {
        void Ekle(Kullanici veri);
        void Sil(Kullanici veri);
        void Guncelle(Kullanici veri);
        Kullanici IstekGetir(int id);
        Kullanici IstekGetir(string KullaniciAdi);
        Kullanici EpostaIleGetir(string eposta);
        List<Kullanici> HepsiniGetir();
        void TakipEt(Kullanici takipEden, int kimi);
        void TakiptenCikar(Kullanici takiptenCikaran, int kimi);
    }
}
