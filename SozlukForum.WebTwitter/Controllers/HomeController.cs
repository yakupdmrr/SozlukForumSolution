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
using static SozlukForum.WebTwitter.Helper.MyClass;


namespace SozlukForum.WebTwitter.Controllers
{
    [_SessionControl]
    [Authorize]
    public class HomeController : Controller
    {
        ProfilResmiYonetimi profilResmiYonetimi = ProfilResmiYonetimi.NesneUret();
        KullaniciYonetimi kullaniciYonetimi = KullaniciYonetimi.NesneUret();
        PaylasimYonetimi paylasimYonetimi = PaylasimYonetimi.NesneUret();
        PaylasimMetniYonetimi paylasimMetniYonetimi = PaylasimMetniYonetimi.NesneUret();
        PaylasimResmiYonetimi paylasimResmiYonetimi = PaylasimResmiYonetimi.NesneUret();
        YorumYonetimi yorumYonetimi = YorumYonetimi.NesneUret();
        EtkilesimLikeYonetimi etkilesimLikeYonetimi = EtkilesimLikeYonetimi.NesneUret();
        EtkilesimDislikeYonetimi etkilesimDislikeYonetimi = EtkilesimDislikeYonetimi.NesneUret();
        KategoriYonetimi kategoriYonetimi = KategoriYonetimi.NesneUret();

        public ActionResult Index()
        {
            var paylasimlar = paylasimYonetimi.HepsiniGetir();

            List<PaylasimViewModel> modeller = new List<PaylasimViewModel>();

            ViewBag.userid = getKullanici(User).KullaniciId;

            for (var i = 0; i < paylasimlar.Count; i++)
            {
                List<Yorum> yorumlar = yorumYonetimi.IstekGetir(paylasimlar[i].PaylasimId);
                var kullanici = kullaniciYonetimi.IstekGetir(paylasimlar[i].KullaniciId);
                List<EtkilesimLike> Likeler = etkilesimLikeYonetimi.IstekGetir(paylasimlar[i].PaylasimId);
                List<EtkilesimDislike> dislikes = etkilesimDislikeYonetimi.IstekGetir(paylasimlar[i].PaylasimId);

                if (paylasimlar[i].PaylasimTipi == 1)
                {

                    modeller.Add(new PaylasimViewModel
                    {
                        Kullanici = kullanici,
                        PaylasimId = paylasimlar[i].PaylasimId,
                        PaylasimMetni = paylasimMetniYonetimi.IstekGetir(paylasimlar[i].PaylasimId),
                        PaylasimResimleri = null,
                        ProfilResmi = profilResmiYonetimi.IstekGetir(kullanici.KullaniciId),
                        Yorumlar = yorumlar,
                        EtkilesimDislikelar = dislikes,
                        EtkilesimLikelar = Likeler,
                        Kategori = kategoriYonetimi.IstekGetir(paylasimlar[i].KategoriId),
                        GirilmeZamani = paylasimlar[i].GirilmeZamani
                    });

                }
                else if (paylasimlar[i].PaylasimTipi == 2)
                {
                    modeller.Add(new PaylasimViewModel
                    {
                        Kullanici = kullanici,
                        PaylasimId = paylasimlar[i].PaylasimId,
                        PaylasimMetni = null,
                        PaylasimResimleri = paylasimResmiYonetimi.IstekGetir(paylasimlar[i].PaylasimId),
                        ProfilResmi = profilResmiYonetimi.IstekGetir(kullanici.KullaniciId),
                        Yorumlar = yorumlar,
                        EtkilesimDislikelar = dislikes,
                        EtkilesimLikelar = Likeler,
                        Kategori = kategoriYonetimi.IstekGetir(paylasimlar[i].KategoriId),
                        GirilmeZamani = paylasimlar[i].GirilmeZamani

                    });
                }
                else
                {
                    modeller.Add(new PaylasimViewModel
                    {
                        Kullanici = kullanici,
                        PaylasimId = paylasimlar[i].PaylasimId,
                        PaylasimMetni = paylasimMetniYonetimi.IstekGetir(paylasimlar[i].PaylasimId),
                        PaylasimResimleri = paylasimResmiYonetimi.IstekGetir(paylasimlar[i].PaylasimId),
                        ProfilResmi = profilResmiYonetimi.IstekGetir(kullanici.KullaniciId),
                        Yorumlar = yorumlar,
                        EtkilesimDislikelar = dislikes,
                        EtkilesimLikelar = Likeler,
                        Kategori = kategoriYonetimi.IstekGetir(paylasimlar[i].KategoriId),
                        GirilmeZamani = paylasimlar[i].GirilmeZamani
                    });
                }
            }
            return View(modeller.OrderByDescending(s => s.GirilmeZamani));
        }
        [HttpGet]
        public JsonResult ProfilResmiBas()
        {
            var login = User.Identity.Name;
            var kullanici = kullaniciYonetimi.EpostaIleGetir(login);
            var profilFoto = profilResmiYonetimi.IstekGetir(kullanici.KullaniciId);
            return Json(profilFoto, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult KullaniciListesi()
        {
            var kullaniciListesi = kullaniciYonetimi.HepsiniGetir();

            return Json(kullaniciListesi, JsonRequestBehavior.AllowGet);
        }
    }

}