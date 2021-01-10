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
    public class YorumMetniYonetimi:IYorumMetniServisi
    {
        private static YorumMetniDal _yorumMetniDal = VeritabaniSecimi.SecilenVeritabani().Fabrika().YorumMetniDalOlustur();

        private static YorumMetniYonetimi _yorumMetniYonetimi;

        private static object _kilit = new object();

        private YorumMetniYonetimi() { }

        public static YorumMetniYonetimi NesneUret()
        {
            lock (_kilit)
            {
                if (_yorumMetniYonetimi == null)
                {
                    
                    _yorumMetniYonetimi = new YorumMetniYonetimi();
                }
            }
            return _yorumMetniYonetimi;
        }
        
        public void Ekle(YorumMetni veri)
        {
            if (String.IsNullOrEmpty(veri.YorumId))
            {
                veri.YorumId = Guid.NewGuid().ToString();
            }
            _yorumMetniDal.Ekle(veri);
        }

        public void Sil(YorumMetni veri)
        {
            _yorumMetniDal.Sil(veri);
        }

        public void Guncelle(YorumMetni veri)
        {
            _yorumMetniDal.Guncelle(veri);
        }

        public YorumMetni IstekGetir(string yorumId)
        {
            return _yorumMetniDal.IstekGetir(yorumId);
        }
    }
}
