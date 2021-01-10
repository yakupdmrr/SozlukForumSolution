using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.İs.Abstracts
{
    public interface IEtkilesimServisi
    {
        void Ekle(Etkilesim veri);
        void Sil(Etkilesim veri);
       List<Etkilesim> HepsiniGetir();
    }
}
