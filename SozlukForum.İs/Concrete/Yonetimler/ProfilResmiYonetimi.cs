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
    public class ProfilResmiYonetimi : IProfilResmiServisi
    {

        private static ProfilResmiDal _profilResmiDal = VeritabaniSecimi.SecilenVeritabani().Fabrika().ProfilResmiDalOlustur();

        private static ProfilResmiYonetimi _profilResmiYonetimi;

        private static object _kilit = new object();

        private ProfilResmiYonetimi() { }

        public static ProfilResmiYonetimi NesneUret()
        {
            lock (_kilit)
            {
                if (_profilResmiYonetimi == null)
                {
                   
                    _profilResmiYonetimi = new ProfilResmiYonetimi();
                }
            }

            return _profilResmiYonetimi;
        }


        public void Ekle(ProfilResmi veri)
        {
           _profilResmiDal.Ekle(veri);
        }

        public void Guncelle(ProfilResmi veri)
        {
            _profilResmiDal.Guncelle(veri);
        }
        
        public ProfilResmi IstekGetir(int kullaniciId)
        {
            return _profilResmiDal.IstekGetir(kullaniciId);
        }

        public void Sil(ProfilResmi veri)
        {
             _profilResmiDal.Sil(veri);
        }
    }
}
