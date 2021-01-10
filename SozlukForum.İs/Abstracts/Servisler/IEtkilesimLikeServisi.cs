using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.İs.Abstracts
{
    public interface IEtkilesimLikeServisi
    {
        void Ekle(EtkilesimLike veri);
        void Sil(EtkilesimLike veri);
        List<EtkilesimLike> IstekGetir(string paylasimId);
       
    }
}
