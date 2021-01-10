using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.İs.Abstracts
{
    public interface IKategoriServisi
    {
        void Ekle(Kategori veri);
        void Sil(Kategori veri);
        void Guncelle(Kategori veri);
        Kategori IstekGetir(int id);
        Kategori IstekGetir(string KategoriAdi);
        List<Kategori> HepsiniGetir();
    }
}
