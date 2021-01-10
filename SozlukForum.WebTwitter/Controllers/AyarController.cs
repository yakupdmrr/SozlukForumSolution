using SozlukForum.İs.Concrete;
using SozlukForum.İs.Concrete.Yonetimler;
using SozlukForum.VeriErisim.Concrete.Sql;
using SozlukForum.Veriler.Concrete;
using SozlukForum.WebTwitter.Helper;
using SozlukForum.WebTwitter.Models;
using SozlukForum.WebTwitter.Models.ViewModeller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SozlukForum.WebTwitter.Controllers
{
    [_SessionControl]
    [Authorize]
    public class AyarController : Controller
    {
        ProfilResmiYonetimi profilResmiYonetimi = ProfilResmiYonetimi.NesneUret();
        KullaniciYonetimi kullaniciYonetimi = KullaniciYonetimi.NesneUret();
        // GET: Ayar
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AyarlarDuzenle(AyarlarModel ayarlarModel)
        {
            var login = User.Identity.Name;
            var kullanici = kullaniciYonetimi.EpostaIleGetir(login);
            SozlukEntitiesTest entities = new SozlukEntitiesTest();
            var kullaniciAyarlar = entities.Kullanicilar.Where(w => w.KullaniciAdi == kullanici.KullaniciAdi).FirstOrDefault();


            try
            {
                if (ModelState.IsValid)
                {

                    kullaniciAyarlar.KullaniciAdi = ayarlarModel.KullaniciAdi;
                    kullaniciAyarlar.Parola = ayarlarModel.Parola;
                    entities.SaveChanges();

                    KullaniciProfilResmi(ayarlarModel, kullanici);
                }
            }
            catch (Exception ex)
            {
                return Json(new { msg = "Hatali:" + ex.Message.ToString(), drm = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { msg = "Basarili", drm = true }, JsonRequestBehavior.AllowGet);
        }
        private void KullaniciProfilResmi(AyarlarModel ayarlarModel, Kullanici kullanici)
        {
            var adres = Server.MapPath("~/Content/images/ProfilResimleri/");

            if (!Directory.Exists(adres))
                Directory.CreateDirectory(adres);

            var neG = Guid.NewGuid();
            string resimname = neG.ToString() + ".jpg";
            ayarlarModel.ProFilResmi.SaveAs(adres + Path.GetFileName(resimname));

            profilResmiYonetimi.Ekle(new ProfilResmi()
            {
                KullaniciId = kullanici.KullaniciId,
                ResimAdi = resimname,
                ResimYolu = "../Content/images/ProfilResimleri/" + resimname
            });
        }

    }
}