﻿using System.Web.Mvc;
using System.Web.Routing;

namespace ExpenseManager
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Filters",
                url: "{controller}/{action}/{filter}/{value}",
                defaults: new { controller = "Home", action = "Index", filter=UrlParameter.Optional, id = UrlParameter.Optional }
            );
        }
    }
}