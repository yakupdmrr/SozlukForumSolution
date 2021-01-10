using SozlukForum.İs.Concrete;
using SozlukForum.VeriErisim.Concrete.Sql;
using SozlukForum.Veriler.Concrete;
using SozlukForum.WebTwitter.Helper;
using SozlukForum.WebTwitter.Models.ViewModeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SozlukForum.WebTwitter.Controllers
{
    [_SessionControl]
    [Authorize]
    public class EtkilesimLikeController : Controller
    {
        KullaniciYonetimi kullaniciYonetimi = KullaniciYonetimi.NesneUret();
        EtkilesimLikeYonetimi etkilesimLikeYonetimi = EtkilesimLikeYonetimi.NesneUret();


        // GET: EtkilesimLike
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EtkilesimLikeEkle(EtkilesimLikeModel etkilesimLike)
        {

            var login = User.Identity.Name;
            var kullanici = kullaniciYonetimi.EpostaIleGetir(login);
            etkilesimLikeYonetimi.Ekle(new EtkilesimLike
            {
                PaylasimId = etkilesimLike.PaylasimId,
                BegenenKullaniciId = kullanici.KullaniciId
            });

            return RedirectToAction("../Home/Index");

        }
        public ActionResult EtkilesimLikeKaldir(EtkilesimLikeModel etkilesimLike)
        {
            var login = User.Identity.Name;
            var kullanici = kullaniciYonetimi.EpostaIleGetir(login);

            etkilesimLikeYonetimi.Sil(new EtkilesimLike
            {
                BegenenKullaniciId = kullanici.KullaniciId,
                PaylasimId = etkilesimLike.PaylasimId
            });

            return RedirectToAction("../Home/Index");
        }   
    }
}