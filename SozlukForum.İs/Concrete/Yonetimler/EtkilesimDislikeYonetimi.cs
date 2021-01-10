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
    public class EtkilesimDislikeYonetimi : IEtkilesimDislikeServisi
    {
        private EtkilesimDislikeDal _etkilesimDislikeDal = VeritabaniSecimi.SecilenVeritabani().Fabrika().EtkilesimDislikeDalOlustur();

        private static EtkilesimDislikeYonetimi _etkilesimDislikeYonetimi;

        private static object _kilit = new object();

        private EtkilesimDislikeYonetimi() { }

        public static EtkilesimDislikeYonetimi NesneUret()
        {
            lock (_kilit)
            {
                if (_etkilesimDislikeYonetimi == null)
                {
                    _etkilesimDislikeYonetimi = new EtkilesimDislikeYonetimi();
                }
            }

            return _etkilesimDislikeYonetimi;
        }
        

        public void Ekle(EtkilesimDislike veri)
        {
            _etkilesimDislikeDal.Ekle(veri);
        }

        
        public List<EtkilesimDislike> IstekGetir(string paylasimId)
        {
            return _etkilesimDislikeDal.IstekGetir(paylasimId);
        }

        public void Sil(EtkilesimDislike veri)
        {
            _etkilesimDislikeDal.Sil(veri);
        }
    }
}
