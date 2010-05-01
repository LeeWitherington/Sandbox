using System.Web.Mvc;
using System.Web.Routing;
using log4net.Config;
using MyShop.UI.Web.MainSite.Core;

namespace MyShop.UI.Web.MainSite
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class Global : MyShopWebApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = ""} // Parameter defaults
                );

            routes.MapRoute(
                "HomePage", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = ""} // Parameter defaults
                );
        }

        protected void Application_Start()
        {
            XmlConfigurator.Configure();
            RegisterRoutes(RouteTable.Routes);
        }
    }
}