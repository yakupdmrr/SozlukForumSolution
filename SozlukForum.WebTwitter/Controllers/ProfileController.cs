using SozlukForum.İs.Concrete;
using SozlukForum.İs.Concrete.Yonetimler;
using SozlukForum.VeriErisim.Concrete.Sql;
using SozlukForum.Veriler.Concrete;
using SozlukForum.WebTwitter.Helper;
using SozlukForum.WebTwitter.Models;
using SozlukForum.WebTwitter.Models.ViewModeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SozlukForum.WebTwitter.Helper.MyClass;

namespace SozlukForum.WebTwitter.Controllers
{
    [_SessionControl]
    [Authorize]
    public class ProfileController : Controller
    {
        // GET: Profile
        KullaniciYonetimi kullaniciYonetimi = KullaniciYonetimi.NesneUret();
        PaylasimYonetimi paylasimYonetimi = PaylasimYonetimi.NesneUret();
        PaylasimMetniYonetimi paylasimMetniYonetimi = PaylasimMetniYonetimi.NesneUret();
        PaylasimResmiYonetimi paylasimResmiYonetimi = PaylasimResmiYonetimi.NesneUret();
        YorumYonetimi yorumYonetimi = YorumYonetimi.NesneUret();
        EtkilesimLikeYonetimi etkilesimLikeYonetimi = EtkilesimLikeYonetimi.NesneUret();
        EtkilesimDislikeYonetimi etkilesimDislikeYonetimi = EtkilesimDislikeYonetimi.NesneUret();
        ProfilResmiYonetimi profilResmiYonetimi = ProfilResmiYonetimi.NesneUret();
        public ActionResult Index()
        {
            var login = User.Identity.Name;
            var kullanici = kullaniciYonetimi.EpostaIleGetir(login);
            var paylasimlar = paylasimYonetimi.HepsiniGetir();
            var kullaniciPaylasimlari = paylasimlar.Where(w => w.KullaniciId == kullanici.KullaniciId).ToList();
            //ViewBag.userid = kullanici.KullaniciId;
            List<ProfileViewModel> profileModel = new List<ProfileViewModel>();
            ViewBag.userid = getKullanici(User).KullaniciId;

            for (int i = 0; i < kullaniciPaylasimlari.Count; i++)
            {
                List<Yorum> yorumlar = yorumYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId);
                List<EtkilesimLike> etkilesimLikes = etkilesimLikeYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId);
                List<EtkilesimDislike> etkilesimDislikes = etkilesimDislikeYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId);

                if (kullaniciPaylasimlari[i].PaylasimTipi == 1)
                {
                    profileModel.Add(new ProfileViewModel
                    {
                        Kullanici = kullanici,
                        GirilmeZamani = kullaniciPaylasimlari[i].GirilmeZamani,
                        PaylasimId = kullaniciPaylasimlari[i].PaylasimId,
                        PaylasimMetni = paylasimMetniYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId),
                        PaylasimResimleri = null,
                        ProfilResmi = profilResmiYonetimi.IstekGetir(kullanici.KullaniciId),
                        Yorumlar = yorumlar,
                        EtkilesimDislikelar = etkilesimDislikes,
                        EtkilesimLikelar = etkilesimLikes

                    });
                }
                else if (kullaniciPaylasimlari[i].PaylasimTipi == 2)
                {
                    profileModel.Add(new ProfileViewModel
                    {
                        Kullanici = kullanici,
                        GirilmeZamani = kullaniciPaylasimlari[i].GirilmeZamani,
                        PaylasimId = kullaniciPaylasimlari[i].PaylasimId,
                        PaylasimMetni = null,
                        PaylasimResimleri = paylasimResmiYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId),
                        ProfilResmi = profilResmiYonetimi.IstekGetir(kullanici.KullaniciId),
                        Yorumlar = yorumlar,
                        EtkilesimDislikelar = etkilesimDislikes,
                        EtkilesimLikelar = etkilesimLikes
                    });
                }
                else
                {
                    profileModel.Add(new ProfileViewModel
                    {
                        Kullanici = kullanici,
                        GirilmeZamani = kullaniciPaylasimlari[i].GirilmeZamani,
                        PaylasimId = kullaniciPaylasimlari[i].PaylasimId,
                        PaylasimMetni = paylasimMetniYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId),
                        PaylasimResimleri = paylasimResmiYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId),
                        ProfilResmi = profilResmiYonetimi.IstekGetir(kullanici.KullaniciId),
                        Yorumlar = yorumlar,
                        EtkilesimDislikelar = etkilesimDislikes,
                        EtkilesimLikelar = etkilesimLikes
                    });
                }
            }
            return View(profileModel.OrderByDescending(s => s.GirilmeZamani));
        }
        [HttpGet]
        public ActionResult PaylasimProfil()
        {
            var KullaniciId = int.Parse(Request.QueryString["KullaniciId"].ToString());
            List<ProfileViewModel> profileModel = new List<ProfileViewModel>();

            var paylasimlar = paylasimYonetimi.HepsiniGetir();
            var kullaniciPaylasimlari = paylasimlar.Where(w => w.KullaniciId == KullaniciId).ToList();
            ViewBag.userid = getKullanici(User).KullaniciId;
            for (int i = 0; i < kullaniciPaylasimlari.Count; i++)
            {
                List<Yorum> yorumlar = yorumYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId);
                List<EtkilesimLike> etkilesimLikes = etkilesimLikeYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId);
                List<EtkilesimDislike> etkilesimDislikes = etkilesimDislikeYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId);
                var kullanici = kullaniciYonetimi.IstekGetir(kullaniciPaylasimlari[i].KullaniciId);
                if (kullaniciPaylasimlari[i].PaylasimTipi == 1)
                {
                    profileModel.Add(new ProfileViewModel
                    {
                        Kullanici = kullanici,
                        GirilmeZamani = kullaniciPaylasimlari[i].GirilmeZamani,
                        PaylasimId = kullaniciPaylasimlari[i].PaylasimId,
                        PaylasimMetni = paylasimMetniYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId),
                        PaylasimResimleri = null,
                        ProfilResmi = profilResmiYonetimi.IstekGetir(KullaniciId),
                        Yorumlar = yorumlar,
                        EtkilesimDislikelar = etkilesimDislikes,
                        EtkilesimLikelar = etkilesimLikes

                    });
                }
                else if (kullaniciPaylasimlari[i].PaylasimTipi == 2)
                {
                    profileModel.Add(new ProfileViewModel
                    {
                        Kullanici = kullanici,
                        GirilmeZamani = kullaniciPaylasimlari[i].GirilmeZamani,
                        PaylasimId = kullaniciPaylasimlari[i].PaylasimId,
                        PaylasimMetni = null,
                        PaylasimResimleri = paylasimResmiYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId),
                        ProfilResmi = profilResmiYonetimi.IstekGetir(KullaniciId),
                        Yorumlar = yorumlar,
                        EtkilesimDislikelar = etkilesimDislikes,
                        EtkilesimLikelar = etkilesimLikes
                    });
                }
                else
                {
                    profileModel.Add(new ProfileViewModel
                    {
                        Kullanici = kullanici,
                        GirilmeZamani = kullaniciPaylasimlari[i].GirilmeZamani,
                        PaylasimId = kullaniciPaylasimlari[i].PaylasimId,
                        PaylasimMetni = paylasimMetniYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId),
                        PaylasimResimleri = paylasimResmiYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId),
                        ProfilResmi = profilResmiYonetimi.IstekGetir(KullaniciId),
                        Yorumlar = yorumlar,
                        EtkilesimDislikelar = etkilesimDislikes,
                        EtkilesimLikelar = etkilesimLikes
                    });
                }
            }
            return View(profileModel.OrderByDescending(s => s.GirilmeZamani));
        }
        [HttpGet]
        public ActionResult YorumProfil()
        {
            List<ProfileViewModel> profileModel = new List<ProfileViewModel>();

            var KullaniciId = int.Parse(Request.QueryString["KullaniciId"].ToString());
            var paylasimListesi = paylasimYonetimi.HepsiniGetir();
            SozlukEntitiesTest ctx = new SozlukEntitiesTest();
            var yorumlar = ctx.Yorumlar.ToList();
            var yorum = yorumlar.Where(w => w.KullaniciId == KullaniciId).FirstOrDefault();
            var kullaniciPaylasimlari = paylasimListesi.Where(w => w.KullaniciId == yorum.KullaniciId).ToList();
            ViewBag.userid = getKullanici(User).KullaniciId;

            for (int i = 0; i < kullaniciPaylasimlari.Count; i++)
            {
                List<Yorum> yorumlars = yorumYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId);
                List<EtkilesimLike> etkilesimLikes = etkilesimLikeYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId);
                List<EtkilesimDislike> etkilesimDislikes = etkilesimDislikeYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId);
                var kullanici = kullaniciYonetimi.IstekGetir(kullaniciPaylasimlari[i].KullaniciId);
                if (kullaniciPaylasimlari[i].PaylasimTipi == 1)
                {
                    profileModel.Add(new ProfileViewModel
                    {
                        Kullanici = kullanici,
                        GirilmeZamani = kullaniciPaylasimlari[i].GirilmeZamani,
                        PaylasimId = kullaniciPaylasimlari[i].PaylasimId,
                        PaylasimMetni = paylasimMetniYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId),
                        PaylasimResimleri = null,
                        ProfilResmi = profilResmiYonetimi.IstekGetir(KullaniciId),
                        Yorumlar = yorumlars,
                        EtkilesimDislikelar = etkilesimDislikes,
                        EtkilesimLikelar = etkilesimLikes

                    });
                }
                else if (kullaniciPaylasimlari[i].PaylasimTipi == 2)
                {
                    profileModel.Add(new ProfileViewModel
                    {
                        Kullanici = kullanici,
                        GirilmeZamani = kullaniciPaylasimlari[i].GirilmeZamani,
                        PaylasimId = kullaniciPaylasimlari[i].PaylasimId,
                        PaylasimMetni = null,
                        PaylasimResimleri = paylasimResmiYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId),
                        ProfilResmi = profilResmiYonetimi.IstekGetir(KullaniciId),
                        Yorumlar = yorumlars,
                        EtkilesimDislikelar = etkilesimDislikes,
                        EtkilesimLikelar = etkilesimLikes
                    });
                }
                else
                {
                    profileModel.Add(new ProfileViewModel
                    {
                        Kullanici = kullanici,
                        GirilmeZamani = kullaniciPaylasimlari[i].GirilmeZamani,
                        PaylasimId = kullaniciPaylasimlari[i].PaylasimId,
                        PaylasimMetni = paylasimMetniYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId),
                        PaylasimResimleri = paylasimResmiYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId),
                        ProfilResmi = profilResmiYonetimi.IstekGetir(KullaniciId),
                        Yorumlar = yorumlars,
                        EtkilesimDislikelar = etkilesimDislikes,
                        EtkilesimLikelar = etkilesimLikes
                    });
                }
            }
            return View(profileModel.OrderByDescending(s => s.GirilmeZamani));
        }
        [HttpGet]
        public ActionResult TakipProfil()
        {
            List<ProfileViewModel> profilModel = new List<ProfileViewModel>();
            var KullaniciId = int.Parse(Request.QueryString["KullaniciId"].ToString());
            var paylasimListesi = paylasimYonetimi.HepsiniGetir();

            var kullanici = kullaniciYonetimi.IstekGetir(KullaniciId);

            var kullaniciPaylasimlari = paylasimListesi.Where(w => w.KullaniciId == kullanici.KullaniciId).ToList();
             ViewBag.userid = getKullanici(User).KullaniciId;

            for (int i = 0; i < kullaniciPaylasimlari.Count; i++)
            {
                List<Yorum> yorumlars = yorumYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId);
                List<EtkilesimLike> etkilesimLikes = etkilesimLikeYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId);
                List<EtkilesimDislike> etkilesimDislikes = etkilesimDislikeYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId);
                var kullaniciX = kullaniciYonetimi.IstekGetir(kullaniciPaylasimlari[i].KullaniciId);
                if (kullaniciPaylasimlari[i].PaylasimTipi == 1)
                {
                    profilModel.Add(new ProfileViewModel
                    {
                        Kullanici = kullaniciX,
                        EtkilesimDislikelar = etkilesimDislikes,
                        EtkilesimLikelar = etkilesimLikes,
                        Yorumlar = yorumlars,
                        GirilmeZamani = kullaniciPaylasimlari[i].GirilmeZamani,
                        PaylasimId = kullaniciPaylasimlari[i].PaylasimId,
                        PaylasimMetni = paylasimMetniYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId),
                        PaylasimResimleri = null,
                        ProfilResmi = profilResmiYonetimi.IstekGetir(kullaniciPaylasimlari[i].KullaniciId)
                    });
                }
                else if (kullaniciPaylasimlari[i].PaylasimTipi == 2)
                {
                    profilModel.Add(new ProfileViewModel
                    {
                        Kullanici = kullaniciX,
                        EtkilesimDislikelar = etkilesimDislikes,
                        EtkilesimLikelar = etkilesimLikes,
                        Yorumlar = yorumlars,
                        GirilmeZamani = kullaniciPaylasimlari[i].GirilmeZamani,
                        PaylasimId = kullaniciPaylasimlari[i].PaylasimId,
                        PaylasimMetni = null,
                        PaylasimResimleri = paylasimResmiYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId),
                        ProfilResmi = profilResmiYonetimi.IstekGetir(kullaniciPaylasimlari[i].KullaniciId)
                    });
                }
                else
                {
                    profilModel.Add(new ProfileViewModel
                    {
                        Kullanici = kullaniciX,
                        EtkilesimDislikelar = etkilesimDislikes,
                        EtkilesimLikelar = etkilesimLikes,
                        Yorumlar = yorumlars,
                        GirilmeZamani = kullaniciPaylasimlari[i].GirilmeZamani,
                        PaylasimId = kullaniciPaylasimlari[i].PaylasimId,
                        PaylasimMetni = paylasimMetniYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId),
                        PaylasimResimleri = paylasimResmiYonetimi.IstekGetir(kullaniciPaylasimlari[i].PaylasimId),
                        ProfilResmi = profilResmiYonetimi.IstekGetir(kullaniciPaylasimlari[i].KullaniciId)
                    });
                }
            }

            return View(profilModel.OrderByDescending(s=>s.GirilmeZamani));
        }
    }
}