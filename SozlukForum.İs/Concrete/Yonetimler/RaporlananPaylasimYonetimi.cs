using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.VeriErisim.Abstracts.VeriErisimBaseleri;
using SozlukForum.Veriler.Concrete;
using SozlukForum.İs.Abstracts;
using SozlukForum.İs.Abstracts.Servisler;
using SozlukForum.İs.Concrete.Secimler;

namespace SozlukForum.İs.Concrete.Yonetimler
{
   public class RaporlananPaylasimYonetimi:IRaporlananPaylasimServisi
    {
        private static RaporlananPaylasimDal _raporlananPaylasimDal = VeritabaniSecimi.SecilenVeritabani().Fabrika().RaporlananPaylasimDalOlustur();

        private static RaporlananPaylasimYonetimi _raporlananPaylasimYonetimi;

        private static object _kilit = new object();

        private RaporlananPaylasimYonetimi() { }

        public static RaporlananPaylasimYonetimi NesneUret()
        {
            lock (_kilit)
            {
                if (_raporlananPaylasimYonetimi == null)
                {
                    
                    _raporlananPaylasimYonetimi = new RaporlananPaylasimYonetimi();
                }
            }

            return _raporlananPaylasimYonetimi;
        }
        
        public void Ekle(RaporlananPaylasim veri)
        {
            _raporlananPaylasimDal.Ekle(veri);
        }

        public void Sil(RaporlananPaylasim veri)
        {
            _raporlananPaylasimDal.Sil(veri);
        }

        public List<RaporlananPaylasim> HepsiniGetir()
        {
            return _raporlananPaylasimDal.HepsiniGetir();
        }
    }
}
