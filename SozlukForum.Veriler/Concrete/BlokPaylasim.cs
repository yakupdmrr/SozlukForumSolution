using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Abstracts;

namespace SozlukForum.Veriler.Concrete
{
    public class BlokPaylasim:INesne
    {
        public int BlokPaylasimId { get; set; }
        public string PaylasimId { get; set; }
    }
}
