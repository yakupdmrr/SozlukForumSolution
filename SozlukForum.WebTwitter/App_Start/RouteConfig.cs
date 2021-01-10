using SozlukForum.İs.Concrete.Secimler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SozlukForum.WebTwitter
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            VeritabaniSecimi.SecimYap(new SQL());

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Acilis", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
