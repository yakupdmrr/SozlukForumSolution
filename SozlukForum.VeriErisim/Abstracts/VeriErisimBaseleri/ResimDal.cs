using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Abstracts;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.VeriErisim.Abstracts.VeriErisimBaseleri
{
    public abstract class ResimDal:VeritabaniIslemi<Resim>
    {
        public abstract void Guncelle(Resim veri);
        public abstract Resim IstekGetir(int id);
        public abstract List<Resim> HepsiniGetir();
    }
}
