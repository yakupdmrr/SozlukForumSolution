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
    public class PaylasimMetniYonetimi:IPaylasimMetniServisi
    {
        private static PaylasimMetniDal _paylasimMetniDal = VeritabaniSecimi.SecilenVeritabani().Fabrika().PaylasimMetniDalOlustur();

        private static PaylasimMetniYonetimi _paylasimMetniYonetimi;

        private static object _kilit = new object();

        private PaylasimMetniYonetimi() { }

        public static PaylasimMetniYonetimi NesneUret()
        {
            lock (_kilit)
            {
                if (_paylasimMetniYonetimi == null)
                {
                    _paylasimMetniYonetimi = new PaylasimMetniYonetimi();
                }
            }
            return _paylasimMetniYonetimi;
        }

        
        public void Ekle(PaylasimMetni veri)
        {
            if (String.IsNullOrEmpty(veri.PaylasimId))
            {
                veri.PaylasimId = Guid.NewGuid().ToString();
            }
            _paylasimMetniDal.Ekle(veri);
        }

        public void Sil(PaylasimMetni veri)
        {
            _paylasimMetniDal.Sil(veri);
        }

        public void Guncelle(PaylasimMetni veri)
        {
            _paylasimMetniDal.Guncelle(veri);
        }

        public PaylasimMetni IstekGetir(string paylasimId)
        {
            return _paylasimMetniDal.IstekGetir(paylasimId);
        }

        public List<PaylasimMetni> HepsiniGetir()
        {
            return _paylasimMetniDal.HepsiniGetir();
        }
    }
}
