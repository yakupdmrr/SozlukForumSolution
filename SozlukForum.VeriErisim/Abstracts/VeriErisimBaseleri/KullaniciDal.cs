using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Abstracts;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.VeriErisim.Abstracts.VeriErisimBaseleri
{
    public abstract class KullaniciDal:VeritabaniIslemi<Kullanici>
    {
        public abstract void Guncelle(Kullanici veri);
        public abstract void TakipEt(Kullanici takipEden, int kimi);
        public abstract void TakiptenCikar(Kullanici takiptenCikaran, int kimi);
        public abstract Kullanici IstekGetir(int id);
        public abstract Kullanici EpostaIleGetir(string eposta);
        public abstract Kullanici IstekGetir(string KullaniciAdi);
        
        public abstract List<Kullanici> HepsiniGetir();
    }
}
