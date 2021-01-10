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
    public class KategoriYonetimi : IKategoriServisi
    {
        private static KategoriDal _kategoriDal = VeritabaniSecimi.SecilenVeritabani().Fabrika().KategoriDalOlustur();

        private static KategoriYonetimi _kategoriYonetimi;

        private static object _kilit = new object();

        private KategoriYonetimi() { }

        public static KategoriYonetimi NesneUret()
        {
            lock (_kilit)
            {
                if (_kategoriYonetimi == null)
                {
                    _kategoriYonetimi = new KategoriYonetimi();
                }
            }

            return _kategoriYonetimi;
        }


        public void Ekle(Kategori veri)
        {
            _kategoriDal.Ekle(veri);
        }

        public void Guncelle(Kategori veri)
        {
            _kategoriDal.Guncelle(veri);
        }

        public Kategori IstekGetir(string KategoriAdi)
        {
            return _kategoriDal.IstekGetir(KategoriAdi);
        }

        public List<Kategori> HepsiniGetir()
        {
            return _kategoriDal.HepsiniGetir();
        }

        public Kategori IstekGetir(int id)
        {
            return _kategoriDal.IstekGetir(id);
        }

        public void Sil(Kategori veri)
        {
            _kategoriDal.Sil(veri);
        }
    }
}
