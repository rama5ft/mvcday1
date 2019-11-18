using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace mvcday1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // routes.MapRoute(
            //    "SearchByEmpIdandName",
            //    "SearchByEmpIdandName/{Empid}/{Empname}",
            //    new { controller = "Home", action = "Edit" }
            //);
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
              "SearchByEmpIdandName1",
              "SearchByEmpIdandName1/{id}/{name}",
              new { controller = "Home", action = "Edit1" }
          );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}
