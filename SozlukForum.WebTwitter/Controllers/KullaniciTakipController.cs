using SozlukForum.İs.Concrete;
using SozlukForum.VeriErisim.Concrete.Sql;
using SozlukForum.Veriler.Concrete;
using SozlukForum.WebTwitter.Models;
using SozlukForum.WebTwitter.Models.ViewModeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SozlukForum.WebTwitter.Controllers
{
    public class KullaniciTakipController : Controller
    {
        KullaniciYonetimi kullaniciYonetimi = KullaniciYonetimi.NesneUret();
        ProfilResmiYonetimi profilResmiYonetimi = ProfilResmiYonetimi.NesneUret();

        // GET: KullaniciTakip
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TakipEtme(int KullaniciId)
        {
            var login = User.Identity.Name;
            var kullanici = kullaniciYonetimi.EpostaIleGetir(login);

            kullaniciYonetimi.TakipEt(kullanici, KullaniciId);

            return RedirectToAction("../Home/Index");
        }
        public ActionResult TakiptenCikarma(int KullaniciId)
        {
            var login = User.Identity.Name;
            var kullanici = kullaniciYonetimi.EpostaIleGetir(login);

            kullaniciYonetimi.TakiptenCikar(kullanici, KullaniciId);

            return RedirectToAction("../Home/Index");
        }



        //Bir Kullanicinin Takipçileri
        [HttpGet]
        public JsonResult KullaniciyiTakipEdenler(int KullaniciId)
        {

            List<TakipViewModel> takipciler = new List<TakipViewModel>();

            var kullanici = kullaniciYonetimi.IstekGetir(KullaniciId);

            var takipçiListesi = kullanici.TakipEdildikleri;

            foreach (var id in takipçiListesi)
            {
                takipciler.Add(new TakipViewModel
                {
                    Kullanici = kullaniciYonetimi.IstekGetir(id),
                    ProfilResmi = profilResmiYonetimi.IstekGetir(id)
                });
            }

            return Json(new { item = takipciler }, JsonRequestBehavior.AllowGet);
        }


        //Bir Kullanicinin Takip Ettikleri
        [HttpGet]
        public JsonResult KullanicininTakipEttikleri(int KullaniciId)
        {
            List<TakipViewModel> takipettikleri = new List<TakipViewModel>();

            var kullanici = kullaniciYonetimi.IstekGetir(KullaniciId);

            var takipEttikleri = kullanici.TakipEttikleri;

            foreach (var id in takipEttikleri)
            {
                takipettikleri.Add(new TakipViewModel
                {
                    Kullanici = kullaniciYonetimi.IstekGetir(id),
                    ProfilResmi = profilResmiYonetimi.IstekGetir(id),
                });
            }
            return Json(new { item = takipettikleri }, JsonRequestBehavior.AllowGet);
        }

    }
}