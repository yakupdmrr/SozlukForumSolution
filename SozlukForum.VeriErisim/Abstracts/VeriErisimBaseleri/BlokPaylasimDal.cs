using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Abstracts;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.VeriErisim.Abstracts.VeriErisimBaseleri
{
    public abstract class BlokPaylasimDal : VeritabaniIslemi<BlokPaylasim>
    {
        public abstract BlokPaylasim IstekGetir(int id);
        public abstract List<BlokPaylasim> HepsiniGetir();
    }
}
