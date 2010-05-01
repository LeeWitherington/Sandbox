using System;
using MyShop.UI.Web.MainSite.Core.Mvc;

namespace MyShop.UI.Web.MainSite.Core
{
    [RegisterVisitAttribute]
    public class MyShopController : System.Web.Mvc.Controller
    {
        public Guid VisitorIdentificationKey
        {
            get
            {
                Guid result = Guid.Empty;

                if(Request.Cookies != null)
                {
                    var cookie = Request.Cookies[RegisterVisitAttribute.VisitorIdentifierKey];

                    if(cookie != null)
                    {
                        result = new Guid(cookie.Value);
                    }
                }
                return result;
            }
        }
    }
}
