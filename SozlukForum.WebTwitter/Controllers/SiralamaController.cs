using SozlukForum.İs.Concrete;
using SozlukForum.İs.Concrete.Yonetimler;
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
    public class SiralamaController : Controller
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
        // GET: Siralama
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult EnCokBegenilenPaylasimlar()
        {
            try
            {
                var paylasimlar = paylasimYonetimi.HepsiniGetir();

                List<PaylasimViewModel> modeller = new List<PaylasimViewModel>();

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
                return Json(new { msg = "Basarili", item = modeller.OrderByDescending(s => s.EtkilesimLikelar.Count).Take(8), drm = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { msg = "Hatali: " + ex.Message.ToString(), drm = false }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}