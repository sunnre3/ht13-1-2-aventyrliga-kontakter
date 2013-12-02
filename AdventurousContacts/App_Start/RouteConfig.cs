using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdventurousContacts
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
			routes.LowercaseUrls = true;

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "error",
				url: "error/{action}/{id}",
				defaults: new { controller = "Error", action = "404", id = UrlParameter.Optional }
			);

			routes.MapRoute(
				name: "Default",
				url: "{action}/{id}",
				defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional }
			);
        }
    }
}