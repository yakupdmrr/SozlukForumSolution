using SozlukForum.Veriler.Concrete;
using SozlukForum.WebTwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SozlukForum.WebTwitter.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (string.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }
            return Redirect("/Home");
        }
        [HttpPost, AllowAnonymous]
        public ActionResult Login(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                SozlukEntitiesTest ctx = new SozlukEntitiesTest();

                var user = ctx.Kullanicilar.Where(w => w.Eposta == kullanici.Eposta && w.Parola == kullanici.Parola).FirstOrDefault();
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(kullanici.Eposta, true);

                    ViewBag.userid = user.KullaniciId;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", " Kullanıcı Adı veya Şifre Hatalı");
                }
            }
            return View(kullanici);
        }
        [ValidateInput(false)]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}