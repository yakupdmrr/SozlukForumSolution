using SozlukForum.Veriler.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.VeriErisim.Abstracts.VeriErisimBaseleri
{
    public abstract class ProfilResmiDal:VeritabaniIslemi<ProfilResmi>
    {
        public abstract void Guncelle(ProfilResmi veri);
        public abstract ProfilResmi IstekGetir(int kullaniciId);
    }
}
