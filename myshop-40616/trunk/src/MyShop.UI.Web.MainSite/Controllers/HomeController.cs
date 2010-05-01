using System.Web.Mvc;
using MyShop.UI.Web.MainSite.Core;

namespace MyShop.UI.Web.MainSite.Controllers
{
    [HandleError]
    public class HomeController : MyShopController
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}