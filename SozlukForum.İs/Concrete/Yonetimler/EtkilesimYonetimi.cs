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
    public class EtkilesimYonetimi : IEtkilesimServisi
    {
        private static EtkilesimYonetimi _etkilesimYonetimi;

        private static EtkilesimDal _etkilesimDal = VeritabaniSecimi.SecilenVeritabani().Fabrika().EtkilesimDalOlustur();

        private static object _kilit = new object();

        private EtkilesimYonetimi() { }

        public static EtkilesimYonetimi NesneUret()
        {
            lock (_kilit)
            {
                if (_etkilesimYonetimi == null)
                {
                    _etkilesimYonetimi = new EtkilesimYonetimi();
                }
            }

            return _etkilesimYonetimi;
        }
        
        public void Ekle(Etkilesim veri)
        {
            _etkilesimDal.Ekle(veri);
        }

        public List<Etkilesim> HepsiniGetir()
        {
            return _etkilesimDal.HepsiniGetir();
        }

      
        public void Sil(Etkilesim veri)
        {
            _etkilesimDal.Sil(veri);
        }
    }
}
