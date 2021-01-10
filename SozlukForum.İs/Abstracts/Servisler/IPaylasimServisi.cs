using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.İs.Abstracts
{
    public interface IPaylasimServisi
    {
        void Ekle(Paylasim veri);
        void Sil(Paylasim veri);
        List<Paylasim> HepsiniGetir();
    }
}
