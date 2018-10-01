using System.Web.Mvc;
using System.Web.Routing;

namespace AttendeeApp.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{attendeeid}",
                defaults: new { controller = "Home", action = "Index", attendeeid = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "Delete",
            //    url: "attende/delete/{attendeeid}",
            //    defaults: new { controller = "AttendeeManager", action = "Delete"}
            //);

            //routes.MapRoute(
            //    name: "Delete",
            //    url: "attende/add",
            //    defaults: new { controller = "AttendeeManager", action = "Add" }
            //);
        }
    }
}
