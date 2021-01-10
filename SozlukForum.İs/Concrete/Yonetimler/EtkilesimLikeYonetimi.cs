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
    public class EtkilesimLikeYonetimi : IEtkilesimLikeServisi
    {
        private static EtkilesimLikeDal _etkilesimLikeDal = VeritabaniSecimi.SecilenVeritabani().Fabrika().EtkilesimLikeDalOlustur();

        private static EtkilesimLikeYonetimi _etkilesimLikeYonetimi;

        private static object _kilit = new object();

        private EtkilesimLikeYonetimi() { }

        public static EtkilesimLikeYonetimi NesneUret()
        {
            lock (_kilit)
            {
                if (_etkilesimLikeYonetimi == null)
                {
                    _etkilesimLikeYonetimi = new EtkilesimLikeYonetimi();
                }
            }

            return _etkilesimLikeYonetimi;
        }
        
        public void Ekle(EtkilesimLike veri)
        {
            _etkilesimLikeDal.Ekle(veri);
        }

        
        public List<EtkilesimLike> IstekGetir(string paylasimId)
        {
           return _etkilesimLikeDal.IstekGetir(paylasimId);
        }

        public void Sil(EtkilesimLike veri)
        {
            _etkilesimLikeDal.Sil(veri);
        }
    }
}
