using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.İs.Concrete.Secimler.Fabrikalar;

namespace SozlukForum.İs.Concrete.Secimler
{
    public class SQL : Veritabani
    {
        public SQL() : base(new SQLFabrikasi())
        {

        }
    }
}
