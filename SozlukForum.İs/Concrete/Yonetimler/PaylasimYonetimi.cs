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
   public class PaylasimYonetimi:IPaylasimServisi
    {

        private static PaylasimDal _paylasimDal = VeritabaniSecimi.SecilenVeritabani().Fabrika().PaylasimDalOlustur();

        private static PaylasimYonetimi _paylasimYonetimi;

        private static object _kilit = new object();

        private PaylasimYonetimi() { }

        public static PaylasimYonetimi NesneUret()
        {
            lock (_kilit)
            {
                if (_paylasimYonetimi == null)
                {
                   _paylasimYonetimi = new PaylasimYonetimi();
                }
            }

            return _paylasimYonetimi;
        }

        
        public void Ekle(Paylasim veri)
        {
            if (String.IsNullOrEmpty(veri.PaylasimId))
            {
                veri.PaylasimId = Guid.NewGuid().ToString();
            }
            _paylasimDal.Ekle(veri);
        }

        public void Sil(Paylasim veri)
        {
            _paylasimDal.Sil(veri);
        }

       
        public List<Paylasim> HepsiniGetir()
        {
           return _paylasimDal.HepsiniGetir();
        }
    }
}
