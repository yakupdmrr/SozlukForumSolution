using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.VeriErisim.Abstracts;
using SozlukForum.VeriErisim.Abstracts.VeriErisimBaseleri;
using SozlukForum.Veriler.Concrete;
using SozlukForum.İs.Abstracts;
using SozlukForum.İs.Concrete.Secimler;

namespace SozlukForum.İs.Concrete
{
    public class BlokPaylasimYonetimi : IBlokPaylasimServisi
    {

        private BlokPaylasimDal _blokPaylasimDal = VeritabaniSecimi.SecilenVeritabani().Fabrika().BlokPaylasimDalOlustur();

        private static BlokPaylasimYonetimi _blokPaylasimYonetimi;

        private static object _kilit = new object();

        private BlokPaylasimYonetimi() { }

        public static BlokPaylasimYonetimi NesneUret()
        {
            lock (_kilit)
            {
                if (_blokPaylasimYonetimi == null)
                {
                   
                    _blokPaylasimYonetimi = new BlokPaylasimYonetimi();
                }
            }

            return _blokPaylasimYonetimi;
        }


        public void Ekle(BlokPaylasim veri)
        {
            _blokPaylasimDal.Ekle(veri);
        }

        public void Sil(BlokPaylasim veri)
        {
            _blokPaylasimDal.Sil(veri);
        }

        public BlokPaylasim IstekGetir(int id)
        {
            return _blokPaylasimDal.IstekGetir(id);
        }

        public List<BlokPaylasim> HepsiniGetir()
        {
            return _blokPaylasimDal.HepsiniGetir();
        }
    }
}
