using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.VeriErisim.Abstracts.VeriErisimBaseleri;
using SozlukForum.İs.Abstracts;
using SozlukForum.Veriler.Concrete;
using SozlukForum.İs.Abstracts.Servisler;
using SozlukForum.İs.Concrete.Secimler;

namespace SozlukForum.İs.Concrete
{
    public class YorumYonetimi : IYorumServisi
    {
        private static YorumDal _yorumDal = VeritabaniSecimi.SecilenVeritabani().Fabrika().YorumDalOlustur();

        private static YorumYonetimi _yorumYonetimi;

        private static object _kilit = new object();

        private YorumYonetimi()
        {

        }

        public static YorumYonetimi NesneUret()
        {
            lock (_kilit)
            {
                if (_yorumYonetimi == null)
                {
                    
                    _yorumYonetimi = new YorumYonetimi();
                }
            }

            return _yorumYonetimi;
        }
        
        public void Ekle(Yorum veri)
        {
            if (String.IsNullOrEmpty(veri.YorumId))
            {
                veri.YorumId = Guid.NewGuid().ToString();
            }
            _yorumDal.Ekle(veri);
        }

        public List<Yorum> IstekGetir(string paylasimId)
        {
            return _yorumDal.IstekGetir(paylasimId);
        }

        public void Sil(Yorum veri)
        {
           _yorumDal.Sil(veri);
        }
    }
}