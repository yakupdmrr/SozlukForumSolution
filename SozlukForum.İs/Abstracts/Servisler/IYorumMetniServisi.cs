using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.İs.Abstracts.Servisler
{
   public interface IYorumMetniServisi
   {
       void Ekle(YorumMetni veri);
       void Sil(YorumMetni veri);
       void Guncelle(YorumMetni veri);
       YorumMetni IstekGetir(string yorumId);

   }
}
