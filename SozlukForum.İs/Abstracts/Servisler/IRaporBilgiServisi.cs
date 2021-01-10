using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.İs.Abstracts.Servisler
{
    public interface IRaporBilgiServisi
    {
        void Ekle(RaporBilgisi veri);
        void Sil(RaporBilgisi veri);
        int PaylasiminRaporSayisi(string paylasimId);
    }
}
