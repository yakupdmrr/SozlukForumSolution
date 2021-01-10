using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Abstracts;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.VeriErisim.Abstracts.VeriErisimBaseleri
{
    public abstract class KategoriDal:VeritabaniIslemi<Kategori>
    {
        public abstract void Guncelle(Kategori veri);
        public abstract Kategori IstekGetir(int id);
        public abstract Kategori IstekGetir(string KategoriAdi);
        public abstract List<Kategori> HepsiniGetir();
    }
}