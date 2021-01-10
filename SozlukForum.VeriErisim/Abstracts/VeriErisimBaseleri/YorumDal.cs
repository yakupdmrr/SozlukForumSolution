using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.VeriErisim.Abstracts.VeriErisimBaseleri
{
    public abstract class YorumDal:VeritabaniIslemi<Yorum>
    {
        public abstract List<Yorum> IstekGetir(string PaylasimId);
    }
}
