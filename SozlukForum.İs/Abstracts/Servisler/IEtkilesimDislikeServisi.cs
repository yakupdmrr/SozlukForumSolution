using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.İs.Abstracts
{
    public interface IEtkilesimDislikeServisi
    {
        void Ekle(EtkilesimDislike veri);
        void Sil(EtkilesimDislike veri);
        List<EtkilesimDislike> IstekGetir(string paylasimId);
       
    }
}
