using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.İs.Abstracts
{
   public interface IYorumResmiServisi
    {
        void Ekle(YorumResmi veri);
        void Sil(YorumResmi veri);
        void Guncelle(YorumResmi veri);
        List<YorumResmi> IstekGetir(string YorumId);
        
    }
}
