using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.VeriErisim.Abstracts.VeriErisimBaseleri
{
    public abstract class PaylasimResmiDal:VeritabaniIslemi<PaylasimResmi>
    {
        public abstract void Guncelle(PaylasimResmi veri);
        public abstract List<PaylasimResmi> IstekGetir(string PaylasimId);
        public abstract List<PaylasimResmi> HepsiniGetir();
    }
}
