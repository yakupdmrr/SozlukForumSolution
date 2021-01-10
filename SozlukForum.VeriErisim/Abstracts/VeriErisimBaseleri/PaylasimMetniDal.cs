using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.VeriErisim.Abstracts.VeriErisimBaseleri
{
   public abstract class PaylasimMetniDal:VeritabaniIslemi<PaylasimMetni>
    {
        public abstract void Guncelle(PaylasimMetni veri);
        public abstract PaylasimMetni IstekGetir(string paylasimId);
        public abstract List<PaylasimMetni> HepsiniGetir();
    }
}
