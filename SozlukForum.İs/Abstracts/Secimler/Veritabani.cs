using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukForum.İs.Concrete.Secimler
{
    public class Veritabani
    {
        private IVeritabaniFabrikasi _veritabaniFabrikasi;

        public Veritabani(IVeritabaniFabrikasi veritabaniFabrikasi)
        {
            _veritabaniFabrikasi = veritabaniFabrikasi;
        }

        public IVeritabaniFabrikasi Fabrika()
        {
            return _veritabaniFabrikasi;
        }

    }
}
