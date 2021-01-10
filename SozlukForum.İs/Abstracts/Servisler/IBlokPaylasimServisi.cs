using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.İs.Abstracts
{
    public interface IBlokPaylasimServisi
    {
        void Ekle(BlokPaylasim veri);
        void Sil(BlokPaylasim veri);
        BlokPaylasim IstekGetir(int id);
        List<BlokPaylasim> HepsiniGetir();
       
    }
}
