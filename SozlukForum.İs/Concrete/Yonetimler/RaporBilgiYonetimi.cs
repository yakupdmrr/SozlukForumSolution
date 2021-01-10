using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.VeriErisim.Abstracts.VeriErisimBaseleri;
using SozlukForum.Veriler.Concrete;
using SozlukForum.İs.Abstracts.Servisler;
using SozlukForum.İs.Concrete.Secimler;

namespace SozlukForum.İs.Concrete.Yonetimler
{
   public class RaporBilgiYonetimi:IRaporBilgiServisi
    {
        private static RaporBilgiDal _raporBilgiDal = VeritabaniSecimi.SecilenVeritabani().Fabrika().RaporBilgiDalOlustur();

        private static RaporBilgiYonetimi _raporlananPaylasimYonetimi;

        private static object _kilit = new object();

        private RaporBilgiYonetimi() { }

        public static RaporBilgiYonetimi NesneUret()
        {
            lock (_kilit)
            {
                if (_raporlananPaylasimYonetimi == null)
                {
                    
                    _raporlananPaylasimYonetimi = new RaporBilgiYonetimi();
                }
            }

            return _raporlananPaylasimYonetimi;
        }

        

        public void Ekle(RaporBilgisi veri)
        {
            _raporBilgiDal.Ekle(veri);
        }

        public void Sil(RaporBilgisi veri)
        {
            _raporBilgiDal.Ekle(veri);
        }

        public int PaylasiminRaporSayisi(string paylasimId)
        {
            return _raporBilgiDal.PaylasiminRaporSayisi(paylasimId);
        }
    }
}
