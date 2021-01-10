using Newtonsoft.Json;
using SozlukForum.İs.Concrete;
using SozlukForum.VeriErisim.Concrete.Sql;
using SozlukForum.Veriler.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace SozlukForum.WebTwitter.Helper
{
    public class MyClass
    {
        public static Kullanici getKullanici(IPrincipal User)
        {
            var login = User.Identity.Name;
            KullaniciYonetimi kullaniciYonetimi = KullaniciYonetimi.NesneUret();
            var pu = kullaniciYonetimi.EpostaIleGetir(login);
            return pu;
        }
    }
}