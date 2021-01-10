using SozlukForum.İs.Concrete;
using SozlukForum.İs.Concrete.Yonetimler;
using SozlukForum.VeriErisim.Concrete.Sql;
using SozlukForum.Veriler.Concrete;
using SozlukForum.WebTwitter.Helper;
using SozlukForum.WebTwitter.Models;
using SozlukForum.WebTwitter.Models.ViewModeller;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SozlukForum.WebTwitter.Helper.MyClass;


namespace SozlukForum.WebTwitter.Controllers
{
    [_SessionControl]
    [Authorize]
    public class YorumController : Controller
    {
        KullaniciYonetimi kullaniciYonetimi = KullaniciYonetimi.NesneUret();
        YorumMetniYonetimi yorumMetniYonetimi = YorumMetniYonetimi.NesneUret();
        YorumResmiYonetimi yorumresmiYonetimi = YorumResmiYonetimi.NesneUret();
        YorumYonetimi yorumYonetimi = YorumYonetimi.NesneUret();
        ProfilResmiYonetimi profilResmiYonetimi = ProfilResmiYonetimi.NesneUret();
        PaylasimYonetimi paylasimYonetimi = PaylasimYonetimi.NesneUret();
        PaylasimMetniYonetimi paylasimMetniYonetimi = PaylasimMetniYonetimi.NesneUret();
        PaylasimResmiYonetimi paylasimResmiYonetimi = PaylasimResmiYonetimi.NesneUret();
        EtkilesimLikeYonetimi etkilesimLikeYonetimi = EtkilesimLikeYonetimi.NesneUret();
        EtkilesimDislikeYonetimi etkilesimDislikeYonetimi = EtkilesimDislikeYonetimi.NesneUret();

        // GET: Yorum
        public ActionResult Index()
        {

            var PaylasimId = Request.QueryString["PaylasimId"].ToString();
            var paylasimListesi = paylasimYonetimi.HepsiniGetir();
            var paylasim = paylasimListesi.Where(w => w.PaylasimId == PaylasimId).FirstOrDefault();
            var kullanici = kullaniciYonetimi.IstekGetir(paylasim.KullaniciId);
            TekPaylasimViewModel tekPaylasimViewModel = new TekPaylasimViewModel();
            List<Yorum> yorumlar = yorumYonetimi.IstekGetir(paylasim.PaylasimId);
            List<EtkilesimDislike> dislikes = etkilesimDislikeYonetimi.IstekGetir(paylasim.PaylasimId);
            List<EtkilesimLike> likes = etkilesimLikeYonetimi.IstekGetir(paylasim.PaylasimId);
            ViewBag.userid = getKullanici(User).KullaniciId;

            if (paylasim.PaylasimTipi == 1)
            {

                tekPaylasimViewModel.PaylasimId = paylasim.PaylasimId;
                tekPaylasimViewModel.Kullanici = kullanici;
                tekPaylasimViewModel.PaylasimMetni = paylasimMetniYonetimi.IstekGetir(paylasim.PaylasimId);
                tekPaylasimViewModel.PaylasimResimleri = null;
                tekPaylasimViewModel.GirilmeZamani = paylasim.GirilmeZamani;
                tekPaylasimViewModel.ProfilResmi = profilResmiYonetimi.IstekGetir(paylasim.KullaniciId);
                tekPaylasimViewModel.EtkilesimLikelar = likes;
                tekPaylasimViewModel.EtkilesimDislikelar = dislikes;
                tekPaylasimViewModel.Yorumlar = yorumlar;



            }
            else if (paylasim.PaylasimTipi == 2)
            {
                tekPaylasimViewModel.PaylasimId = paylasim.PaylasimId;
                tekPaylasimViewModel.Kullanici = kullanici;
                tekPaylasimViewModel.PaylasimMetni = null;
                tekPaylasimViewModel.PaylasimResimleri = paylasimResmiYonetimi.IstekGetir(paylasim.PaylasimId); ;
                tekPaylasimViewModel.GirilmeZamani = paylasim.GirilmeZamani;
                tekPaylasimViewModel.ProfilResmi = profilResmiYonetimi.IstekGetir(paylasim.KullaniciId);
                tekPaylasimViewModel.EtkilesimLikelar = likes;
                tekPaylasimViewModel.EtkilesimDislikelar = dislikes;
                tekPaylasimViewModel.Yorumlar = yorumlar;
            }
            else
            {
                tekPaylasimViewModel.PaylasimId = paylasim.PaylasimId;
                tekPaylasimViewModel.Kullanici = kullanici;
                tekPaylasimViewModel.PaylasimMetni = paylasimMetniYonetimi.IstekGetir(paylasim.PaylasimId);
                tekPaylasimViewModel.PaylasimResimleri = paylasimResmiYonetimi.IstekGetir(paylasim.PaylasimId); ;
                tekPaylasimViewModel.GirilmeZamani = paylasim.GirilmeZamani;
                tekPaylasimViewModel.ProfilResmi = profilResmiYonetimi.IstekGetir(paylasim.KullaniciId);
                tekPaylasimViewModel.EtkilesimLikelar = likes;
                tekPaylasimViewModel.EtkilesimDislikelar = dislikes;
                tekPaylasimViewModel.Yorumlar = yorumlar;
            }

            return View(tekPaylasimViewModel);

        }
        //Yorumlar Listeniyor
        public JsonResult GetYorumlar(string PaylasimId)
        {
            try
            {
                List<YorumViewModel> yorumlar = new List<YorumViewModel>();

                var paylasimYorumlari = yorumYonetimi.IstekGetir(PaylasimId);

                for (int i = 0; i < paylasimYorumlari.Count; i++)
                {
                    var kullanici = kullaniciYonetimi.IstekGetir(paylasimYorumlari[i].KullaniciId);

                    if (paylasimYorumlari[i].YorumTipi == 1)
                    {
                        yorumlar.Add(new YorumViewModel
                        {
                            Kullanici = kullanici,
                            PaylasimId = paylasimYorumlari[i].PaylasimId,
                            ProfilResmi = profilResmiYonetimi.IstekGetir(kullanici.KullaniciId),
                            YapilmaZamani = paylasimYorumlari[i].YapilmaZamani,
                            YorumId = paylasimYorumlari[i].YorumId,
                            YorumMetni = yorumMetniYonetimi.IstekGetir(paylasimYorumlari[i].YorumId),
                            YorumResimleri = null,

                        });
                    }
                    else if (paylasimYorumlari[i].YorumTipi == 2)
                    {
                        yorumlar.Add(new YorumViewModel
                        {
                            Kullanici = kullanici,
                            PaylasimId = paylasimYorumlari[i].PaylasimId,
                            ProfilResmi = profilResmiYonetimi.IstekGetir(kullanici.KullaniciId),
                            YapilmaZamani = paylasimYorumlari[i].YapilmaZamani,
                            YorumId = paylasimYorumlari[i].YorumId,
                            YorumMetni = null,
                            YorumResimleri = yorumresmiYonetimi.IstekGetir(paylasimYorumlari[i].YorumId)
                        });
                    }
                    else
                    {
                        yorumlar.Add(new YorumViewModel
                        {
                            Kullanici = kullanici,
                            PaylasimId = paylasimYorumlari[i].PaylasimId,
                            ProfilResmi = profilResmiYonetimi.IstekGetir(kullanici.KullaniciId),
                            YapilmaZamani = paylasimYorumlari[i].YapilmaZamani,
                            YorumId = paylasimYorumlari[i].YorumId,
                            YorumMetni = yorumMetniYonetimi.IstekGetir(paylasimYorumlari[i].YorumId),
                            YorumResimleri = yorumresmiYonetimi.IstekGetir(paylasimYorumlari[i].YorumId)
                        });
                    }
                }
                return Json(new { item = yorumlar, drm = true, msg = "Basarili" }, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                return Json(new { msg = "Hatali:" + ex.Message.ToString(), drm = false }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult YorumEkle(YorumEkleModel yorumEkleModel)
        {
            var login = User.Identity.Name;
            var kullanici = kullaniciYonetimi.EpostaIleGetir(login);
            try
            {
                if (ModelState.IsValid)
                {
                    if (yorumEkleModel.YorumMetni != null && yorumEkleModel.YorumResimleri[0] == null)
                    {
                        string YorumId = Guid.NewGuid().ToString();

                        yorumMetniYonetimi.Ekle(new YorumMetni()
                        {
                            GirilenMetin = yorumEkleModel.YorumMetni,
                            KullaniciId = kullanici.KullaniciId,
                            YapilmaZamani = DateTime.Now.ToString(),
                            YorumId = YorumId,
                            PaylasimId = yorumEkleModel.PaylasimId
                        });
                    }

                    else if (yorumEkleModel.YorumMetni == null && yorumEkleModel.YorumResimleri[0] != null)
                    {
                        string YorumId = Guid.NewGuid().ToString();

                        var yorumResimListesi = YorumResimleri(yorumEkleModel, kullanici);

                        foreach (var item in yorumResimListesi)
                        {
                            item.YorumId = YorumId;
                            item.PaylasimId = yorumEkleModel.PaylasimId;
                            yorumresmiYonetimi.Ekle(item);
                        }
                    }
                    else
                    {
                        string YorumId = Guid.NewGuid().ToString();
                        yorumMetniYonetimi.Ekle(new YorumMetni()
                        {
                            GirilenMetin = yorumEkleModel.YorumMetni,
                            KullaniciId = kullanici.KullaniciId,
                            YapilmaZamani = DateTime.Now.ToString(),
                            YorumId = YorumId,
                            PaylasimId = yorumEkleModel.PaylasimId
                        });

                        var yorumResimListesi = YorumResimleri(yorumEkleModel, kullanici);

                        foreach (var item in yorumResimListesi)
                        {
                            item.PaylasimId = yorumEkleModel.PaylasimId;
                            item.YorumId = YorumId;
                            yorumresmiYonetimi.Ekle(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { msg = "Hatali:" + ex.Message.ToString(), drm = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { msg = "Basaril", drm = true }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ProfileYorum(int KullaniciId)
        {
            try
            {
                List<KullaniciYorumlariViewModel> kullaniciYorumlarimodel = new List<KullaniciYorumlariViewModel>();
                SozlukEntitiesTest ctx = new SozlukEntitiesTest();
                var yorumlarListesi = ctx.Yorumlar.ToList();
                var kullaniciYorumlari = yorumlarListesi.Where(w => w.KullaniciId == KullaniciId).ToList();

                for (int i = 0; i < kullaniciYorumlari.Count; i++)
                {
                    var kullanici = kullaniciYonetimi.IstekGetir(KullaniciId);

                    if (kullaniciYorumlari[i].YorumTipi == 1)
                    {
                        kullaniciYorumlarimodel.Add(new KullaniciYorumlariViewModel
                        {
                            Kullanici = kullanici,
                            ProfilResmi = profilResmiYonetimi.IstekGetir(KullaniciId),
                            YapilmaZamani = kullaniciYorumlari[i].YapilmaZamani,
                            YorumId = kullaniciYorumlari[i].YorumId,
                            YorumMetni = yorumMetniYonetimi.IstekGetir(kullaniciYorumlari[i].YorumId),
                            YorumResimleri = null,
                        });
                    }
                   else if (kullaniciYorumlari[i].YorumTipi == 2)
                    {
                        kullaniciYorumlarimodel.Add(new KullaniciYorumlariViewModel
                        {
                            Kullanici = kullanici,
                            ProfilResmi = profilResmiYonetimi.IstekGetir(KullaniciId),
                            YapilmaZamani = kullaniciYorumlari[i].YapilmaZamani,
                            YorumId = kullaniciYorumlari[i].YorumId,
                            YorumMetni = null,
                            YorumResimleri = yorumresmiYonetimi.IstekGetir(kullaniciYorumlari[i].YorumId),
                        });
                    }
                    else
                    {
                        kullaniciYorumlarimodel.Add(new KullaniciYorumlariViewModel
                        {
                            Kullanici = kullanici,
                            ProfilResmi = profilResmiYonetimi.IstekGetir(KullaniciId),
                            YapilmaZamani = kullaniciYorumlari[i].YapilmaZamani,
                            YorumId = kullaniciYorumlari[i].YorumId,
                            YorumMetni = yorumMetniYonetimi.IstekGetir(kullaniciYorumlari[i].YorumId),
                            YorumResimleri = yorumresmiYonetimi.IstekGetir(kullaniciYorumlari[i].YorumId),
                        });
                    }
                }
                return Json(new { item = kullaniciYorumlarimodel, drm = true, msg = "Basarili" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { drm = false, msg = "Hatali: " + ex.Message.ToString() }, JsonRequestBehavior.AllowGet);

            }

        }

        public ActionResult YorumSil(string YorumId)
        {
            SozlukEntitiesTest ctx = new SozlukEntitiesTest();
            var delete = ctx.Yorumlar.Where(w => w.YorumId == YorumId).FirstOrDefault();
            if (delete != null)
            {
                ctx.Entry(delete).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Redirect("../Profile/Index");
        }
        private List<YorumResmi> YorumResimleri(YorumEkleModel yorumEkleModel, Kullanici kullanici)
        {
            List<YorumResmi> yorumResimleri = new List<YorumResmi>();
            var adres = Server.MapPath("~/Content/images/YorumResimleri/");

            if (!Directory.Exists(adres))
                Directory.CreateDirectory(adres);

            foreach (var item in yorumEkleModel.YorumResimleri)
            {
                var neG = Guid.NewGuid();
                string resimname = neG.ToString() + ".jpg";
                item.SaveAs(adres + Path.GetFileName(resimname));

                yorumResimleri.Add(new YorumResmi()
                {
                    YapilmaZamani = DateTime.Now.ToString(),
                    KullaniciId = kullanici.KullaniciId,
                    Resim = new Resim
                    {
                        ResimAdi = resimname,
                        ResimYolu = "../Content/images/YorumResimleri/" + resimname
                    }

                });
            }
            return yorumResimleri;
        }

    }
}