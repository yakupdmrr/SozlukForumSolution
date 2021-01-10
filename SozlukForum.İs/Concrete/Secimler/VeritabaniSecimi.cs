using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukForum.İs.Concrete.Secimler
{
    public static class VeritabaniSecimi
    {
        private static Veritabani _veritabani;
       
       
        public static void SecimYap(Veritabani veritabani)
        {
            _veritabani = veritabani;
        }

        public static Veritabani SecilenVeritabani()
        {
            return _veritabani;
        }
    }
}
