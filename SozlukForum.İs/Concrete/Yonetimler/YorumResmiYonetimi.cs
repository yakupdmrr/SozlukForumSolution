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
    public class YorumResmiYonetimi : IYorumResmiServisi
    {
        private static YorumResmiDal _yorumResmiDal = VeritabaniSecimi.SecilenVeritabani().Fabrika().YorumResmiDalOlustur();
        private static YorumResmiYonetimi _yorumResmiYonetimi;

        private static object _kilit = new object();

        private YorumResmiYonetimi() { }

        public static YorumResmiYonetimi NesneUret()
        {
            lock (_kilit)
            {
                if (_yorumResmiYonetimi == null)
                {
                    
                    _yorumResmiYonetimi = new YorumResmiYonetimi();
                }
            }

            return _yorumResmiYonetimi;
        }


        public void Ekle(YorumResmi veri)
        {
            if (String.IsNullOrEmpty(veri.YorumId))
            {
                veri.YorumId = Guid.NewGuid().ToString();
            }
            _yorumResmiDal.Ekle(veri);
        }

        public void Guncelle(YorumResmi veri)
        {
            _yorumResmiDal.Guncelle(veri);
        }

        public List<YorumResmi> IstekGetir(string yorumId)
        {
            return _yorumResmiDal.IstekGetir(yorumId);
        }

        public void Sil(YorumResmi veri)
        {
            _yorumResmiDal.Sil(veri);
        }
    }
}
