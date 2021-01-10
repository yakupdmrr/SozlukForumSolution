using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.İs.Abstracts.Servisler
{
    public interface IYorumServisi
    {
        void Ekle(Yorum veri);
        void Sil(Yorum veri);
        List<Yorum> IstekGetir(string paylasimId);
      
    }
}
