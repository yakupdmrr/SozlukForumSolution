using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.VeriErisim.Abstracts.VeriErisimBaseleri;
using SozlukForum.İs.Abstracts;
using SozlukForum.Veriler.Concrete;
using SozlukForum.İs.Concrete.Secimler;

namespace SozlukForum.İs.Concrete
{
    public class KullaniciYonetimi : IKullaniciServisi
    {
        private static KullaniciDal _kullaniciDal = VeritabaniSecimi.SecilenVeritabani().Fabrika().KullaniciDalOlustur();

        private static KullaniciYonetimi _kullaniciYonetimi;

        private static object _kilit = new object();

        private KullaniciYonetimi()
        {

        }

        public static KullaniciYonetimi NesneUret()
        {
            lock (_kilit)
            {
                if (_kullaniciYonetimi == null)
                {
                    
                    _kullaniciYonetimi = new KullaniciYonetimi();
                }
            }

            return _kullaniciYonetimi;
        }


        public void Ekle(Kullanici veri)
        {
            _kullaniciDal.Ekle(veri);
        }

        public void Guncelle(Kullanici veri)
        {
            _kullaniciDal.Guncelle(veri);
        }

        public List<Kullanici> HepsiniGetir()
        {
            return _kullaniciDal.HepsiniGetir();
        }

        public void Sil(Kullanici veri)
        {
            _kullaniciDal.Sil(veri);
        }

        public void TakipEt(Kullanici takipEden, int kimi)
        {
            if (!takipEden.TakipEttikleri.Contains(kimi))
            {
                _kullaniciDal.TakipEt(takipEden, kimi);
                takipEden.TakipEttikleri.Add(kimi);
            }
        }

        public void TakiptenCikar(Kullanici takiptenCikaran, int kimi)
        {

            if (takiptenCikaran.TakipEttikleri.Contains(kimi))
            {
                _kullaniciDal.TakiptenCikar(takiptenCikaran, kimi);
                takiptenCikaran.TakipEttikleri.Remove(kimi);
            }
        }

        public Kullanici IstekGetir(int id)
        {
           return _kullaniciDal.IstekGetir(id);
        }

        public Kullanici IstekGetir(string KullaniciAdi)
        {
            return _kullaniciDal.IstekGetir(KullaniciAdi);
        }

        public Kullanici EpostaIleGetir(string eposta)
        {
            return _kullaniciDal.EpostaIleGetir(eposta);
        }
    }
}
