using SozlukForum.Veriler.Concrete;
using SozlukForum.WebTwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SozlukForum.WebTwitter.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Kullanici kullanici)
        {
            try
            {
                using (SozlukEntitiesTest ctx = new SozlukEntitiesTest())
                {
                    var kullaniciGetir = ctx.Kullanicilar.ToList();

                    foreach (var item in kullaniciGetir)
                    {
                        if (item.KullaniciAdi == kullanici.KullaniciAdi || item.Eposta == kullanici.Eposta)
                        {
                            return Json(new { msg = "Var olan bir kullanıcı adı ve Eposta girdiniz", durum = false }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    if (ModelState.IsValid)
                    {
                        var kullaniciEkle = ctx.Kullanicilar.Add(new Kullanicilar()
                        {
                            Ad = kullanici.Ad,
                            Soyad = kullanici.Soyad,
                            Eposta = kullanici.Eposta,
                            Parola = kullanici.Parola,
                            KullaniciAdi = kullanici.KullaniciAdi,
                            Yetki=false.ToString()
                        });
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { msg = "Hatali Üye olma İşlemi:" + ex.Message.ToString(), drm = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { msg = "Başarili", drm = true }, JsonRequestBehavior.AllowGet);
        }
    }
}