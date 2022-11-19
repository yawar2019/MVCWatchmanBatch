using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCRockersBatch
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "AboutUS", action = "Index", id = UrlParameter.Optional }
         );









            //routes.MapRoute(
            //    name: "MarvelMovie",
            //    url: "InfinityWar/IRonMan",
            //    defaults: new { controller = "AboutUS", action = "Index", id = UrlParameter.Optional }
            //);

           
        }
    }
}
