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
    public class PaylasimController : Controller
    {
        KullaniciYonetimi kullaniciYonetimi = KullaniciYonetimi.NesneUret();
        PaylasimMetniYonetimi paylasimMetniYonetimi = PaylasimMetniYonetimi.NesneUret();
        PaylasimResmiYonetimi paylasimResmiYonetimi = PaylasimResmiYonetimi.NesneUret();
        KategoriYonetimi kategoriYonetimi = KategoriYonetimi.NesneUret();
        PaylasimYonetimi paylasimYonetimi = PaylasimYonetimi.NesneUret();
        // GET: Paylasim
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult PaylasimEkle(PaylasimEkleModel ekleModel)
        {
            var login = User.Identity.Name;
            var kullanici = kullaniciYonetimi.EpostaIleGetir(login);

            try
            {
                if (ModelState.IsValid)
                {
                    if (ekleModel.PaylasimMetni != null && ekleModel.PaylasimResimleri[0] == null)
                    {
                        paylasimMetniYonetimi.Ekle(new PaylasimMetni
                        {
                            GirilenMetin = ekleModel.PaylasimMetni,
                            GirilmeZamani = DateTime.Now.ToString(),
                            KategoriId = kategoriYonetimi.IstekGetir(ekleModel.KategoriAdi).KategoriId,
                            KullaniciId = kullanici.KullaniciId,


                        });
                    }

                    else if (ekleModel.PaylasimMetni == null && ekleModel.PaylasimResimleri[0] != null)
                    {
                        string paylasimId = Guid.NewGuid().ToString();
                        var liste = ResimleriKlasorle(ekleModel, kullanici);
                        foreach (var item in liste)
                        {
                            item.PaylasimId = paylasimId;
                            paylasimResmiYonetimi.Ekle(item);
                        }
                    }
                    else
                    {
                        string paylasimId = Guid.NewGuid().ToString();
                        paylasimMetniYonetimi.Ekle(new PaylasimMetni
                        {
                            PaylasimId = paylasimId,
                            GirilenMetin = ekleModel.PaylasimMetni,
                            GirilmeZamani = DateTime.Now.ToString(),
                            KategoriId = kategoriYonetimi.IstekGetir(ekleModel.KategoriAdi).KategoriId,
                            KullaniciId = kullanici.KullaniciId,

                        });

                        var liste = ResimleriKlasorle(ekleModel, kullanici);
                        foreach (var item in liste)
                        {
                            item.PaylasimId = paylasimId;
                            paylasimResmiYonetimi.Ekle(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { msg = "Hatali" + ex.Message.ToString(), drm = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { msg = "Basarili", drm = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PaylasimSil(string PaylasimId)
        {
            SozlukEntitiesTest ctx = new SozlukEntitiesTest();

            var delete = ctx.Paylasimlar.Where(w => w.PaylasimId == PaylasimId).FirstOrDefault();

            if (delete != null)
            {
                ctx.Entry(delete).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Redirect("../Profile/Index");
        }
        private List<PaylasimResmi> ResimleriKlasorle(PaylasimEkleModel paylasimEkle, Kullanici kullanici)
        {
            List<PaylasimResmi> paylasimResimleri = new List<PaylasimResmi>();

            var adres = Server.MapPath("~/Content/images/PaylasimResimleri/");

            if (!Directory.Exists(adres))
                Directory.CreateDirectory(adres);

            foreach (var item in paylasimEkle.PaylasimResimleri)
            {
                var neG = Guid.NewGuid();
                string resimname = neG.ToString() + ".jpg";
                item.SaveAs(adres + Path.GetFileName(resimname));
                paylasimResimleri.Add(new PaylasimResmi
                {
                    GirilmeZamani = DateTime.Now.ToString(),
                    KullaniciId = kullanici.KullaniciId,
                    KategoriId = kategoriYonetimi.IstekGetir(paylasimEkle.KategoriAdi).KategoriId,
                    Resim = new Resim
                    {
                        ResimAdi = resimname,
                        ResimYolu = "../Content/images/PaylasimResimleri/" + resimname
                    },
                });
            }
            return paylasimResimleri;
        }
    }
}