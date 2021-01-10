using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Abstracts;

namespace SozlukForum.Veriler.Concrete
{
    public class PaylasimResmi : Paylasim, INesne
    {
       public Resim Resim { get; set; }
    }
}
