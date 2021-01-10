using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.İs.Abstracts.Servisler
{
    public interface IBlokBilgiServisi
    {
        void Ekle(BlokBilgisi veri);
        void Sil(BlokBilgisi veri);
        List<BlokBilgisi> IstekGetir(string paylasimId);
    }
}
