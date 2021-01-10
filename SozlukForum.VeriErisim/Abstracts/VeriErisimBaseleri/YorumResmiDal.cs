using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Abstracts;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.VeriErisim.Abstracts.VeriErisimBaseleri
{
    public abstract class YorumResmiDal:VeritabaniIslemi<YorumResmi>
    {
        public abstract void Guncelle(YorumResmi veri);
        public abstract List<YorumResmi> IstekGetir(string YorumId);
    }
}
