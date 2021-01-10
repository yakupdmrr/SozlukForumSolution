using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.İs.Abstracts
{
    public interface IResimServisi
    {
        void Ekle(Resim veri);
        void Sil(Resim veri);
        void Guncelle(Resim veri);
        Resim IstekGetir(int id);
        List<Resim> HepsiniGetir();

    }

}
