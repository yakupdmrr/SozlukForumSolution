using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.VeriErisim.Abstracts.VeriErisimBaseleri;
using SozlukForum.Veriler.Concrete;
using SozlukForum.İs.Abstracts;
using SozlukForum.İs.Concrete.Secimler;

namespace SozlukForum.İs.Concrete
{
    public class PaylasimResmiYonetimi : IPaylasimResmiServisi
    {
        private static PaylasimResmiDal _paylasimResmiDal = VeritabaniSecimi.SecilenVeritabani().Fabrika().PaylasimResmiDalOlustur();

        private static PaylasimResmiYonetimi _paylasimResmiYonetimi;

        private static object _kilit = new object();

        private PaylasimResmiYonetimi() { }

        public static PaylasimResmiYonetimi NesneUret()
        {
            lock (_kilit)
            {
                if (_paylasimResmiYonetimi == null)
                {
                   _paylasimResmiYonetimi = new PaylasimResmiYonetimi();
                }
            }

            return _paylasimResmiYonetimi;
        }
        

        public void Ekle(PaylasimResmi veri)
        {
            if (String.IsNullOrEmpty(veri.PaylasimId))
            {
                veri.PaylasimId = Guid.NewGuid().ToString();
            }
            _paylasimResmiDal.Ekle(veri);
        }

        public void Sil(PaylasimResmi veri)
        {
            _paylasimResmiDal.Sil(veri);
        }

        public void Guncelle(PaylasimResmi veri)
        {
            _paylasimResmiDal.Guncelle(veri);
        }

        public List<PaylasimResmi> IstekGetir(string paylasimId)
        {
          return  _paylasimResmiDal.IstekGetir(paylasimId);
        }

        public List<PaylasimResmi> HepsiniGetir()
        {
          return  _paylasimResmiDal.HepsiniGetir();
        }
    }
}
