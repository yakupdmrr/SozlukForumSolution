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
    public class ResimYonetimi:IResimServisi
    {

        private static ResimDal _resimDal = VeritabaniSecimi.SecilenVeritabani().Fabrika().ResimDalOlustur();

        private static ResimYonetimi _resimYonetimi;

        private static object _kilit = new object();

        private ResimYonetimi() { }

        public static ResimYonetimi NesneUret()
        {
            lock (_kilit)
            {
                if (_resimYonetimi == null)
                {
                   
                    _resimYonetimi = new ResimYonetimi();
                }
            }

            return _resimYonetimi;
        }


        public void Ekle(Resim veri)
        {
            _resimDal.Ekle(veri);
        }

        public void Sil(Resim veri)
        {
            _resimDal.Sil(veri);
        }

        public void Guncelle(Resim veri)
        {
            _resimDal.Guncelle(veri);
        }

        public Resim IstekGetir(int id)
        {
            return _resimDal.IstekGetir(id);
        }

        public List<Resim> HepsiniGetir()
        {
            return _resimDal.HepsiniGetir();
        }
    }
}
