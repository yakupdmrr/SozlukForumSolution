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
    public class EtkilesimDislikeController : Controller
    {
        KullaniciYonetimi kullaniciYonetimi = KullaniciYonetimi.NesneUret();
        EtkilesimDislikeYonetimi etkilesimDislikeYonetimi = EtkilesimDislikeYonetimi.NesneUret();

        // GET: EtkilesimDislikeEkle
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EtkilesimDislikeEkle(EtkilesimDislikeModel etkilesimDislike)
        {
            
                var login = User.Identity.Name;
                var kullanici = kullaniciYonetimi.EpostaIleGetir(login);
                etkilesimDislikeYonetimi.Ekle(new EtkilesimDislike
                {
                    BegenmeyenKullaniciId = kullanici.KullaniciId,
                    PaylasimId = etkilesimDislike.PaylasimId
                });

            return RedirectToAction("../Home/Index");   
        }
        
        public ActionResult EtkilesimDislikeKaldir(EtkilesimDislikeModel etkilesimDislike)
        {
            var login = User.Identity.Name;
            var kullanici = kullaniciYonetimi.EpostaIleGetir(login);

            etkilesimDislikeYonetimi.Sil(new EtkilesimDislike
            {
                BegenmeyenKullaniciId = kullanici.KullaniciId,
                PaylasimId = etkilesimDislike.PaylasimId
            });

            return RedirectToAction("../Home/Index");
        }
    }
}