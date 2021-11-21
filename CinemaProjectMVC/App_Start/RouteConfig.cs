using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CinemaProjectMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{NumberOfTicketsOrdered}",
                defaults: new { controller = "Orders", action = "Index", id = UrlParameter.Optional, NumberOfTicketsOrdered = UrlParameter.Optional }
            );
        }
    }
}
