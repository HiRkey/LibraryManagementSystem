using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LibraryManagementSystem_A2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            //routes.MapMvcAttributeRoutes();

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new { id = UrlParameter.Optional, controller = "home", action = "index" } );
        }
    }
}
