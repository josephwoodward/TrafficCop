using System.Web.Mvc;
using System.Web.Routing;

namespace TrafficCop.Demo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Core.TrafficCop.Register(new MyCustomRegistry());
        }

        protected void Application_BeginRequest()
        {
            Core.TrafficCop.Watch();
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}