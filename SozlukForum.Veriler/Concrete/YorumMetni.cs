using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.Veriler.Abstracts;

namespace SozlukForum.Veriler.Concrete
{
    public class YorumMetni : Yorum, INesne
    {
        public string GirilenMetin { get; set; }
    }
}
