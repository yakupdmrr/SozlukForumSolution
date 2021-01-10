using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.VeriErisim.Abstracts.VeriErisimBaseleri;
using SozlukForum.Veriler.Concrete;
using SozlukForum.İs.Abstracts.Servisler;
using SozlukForum.İs.Concrete.Secimler;
using SozlukForum.İs.Concrete.Secimler;
namespace SozlukForum.İs.Concrete.Yonetimler
{
   public class BlokBilgisiYonetimi:IBlokBilgiServisi
    {
        
        private static BlokBilgisiYonetimi _blokPaylasimYonetimi;

        private BlokBilgisiDal _blokBilgisiDal = VeritabaniSecimi.SecilenVeritabani().Fabrika().BlokBilgisiDalOlustur();

        private static object _kilit = new object();

        private BlokBilgisiYonetimi() { }

        public static BlokBilgisiYonetimi NesneUret()
        {
            lock (_kilit)
            {
                if (_blokPaylasimYonetimi == null)
                {
                   _blokPaylasimYonetimi = new BlokBilgisiYonetimi();
                }
            }

            return _blokPaylasimYonetimi;
        }

        
        public void Ekle(BlokBilgisi veri)
        {
            _blokBilgisiDal.Ekle(veri);
         }

        public void Sil(BlokBilgisi veri)
        {
            _blokBilgisiDal.Ekle(veri);
        }

        public List<BlokBilgisi> IstekGetir(string paylasimId)
        {
            return _blokBilgisiDal.IstekGetir(paylasimId);
        }
    }
}
