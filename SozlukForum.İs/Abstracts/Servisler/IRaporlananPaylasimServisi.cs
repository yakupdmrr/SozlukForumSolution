using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.İs.Abstracts.Servisler
{
    public interface IRaporlananPaylasimServisi
    {
        void Ekle(RaporlananPaylasim veri);
        void Sil(RaporlananPaylasim veri);
        List<RaporlananPaylasim> HepsiniGetir();
    }

}
