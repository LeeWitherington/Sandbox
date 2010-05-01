using System;
using System.Web.Mvc;
using System.Web.Security;
using MyShop.UI.Web.MainSite.Core;

namespace MyShop.UI.Web.MainSite.Controllers
{
    public class UserController : MyShopController
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(String userName, String password, String email)
        {
            MembershipCreateStatus status;
            Membership.CreateUser(userName, password, email, null, null, true, null, out status);

            if(status == MembershipCreateStatus.Success)
            {
                FormsAuthentication.SetAuthCookie(userName, false);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult LogOn()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            if (Request.UrlReferrer != null && !String.IsNullOrEmpty(Request.UrlReferrer.ToString()))
            {
                string url = Request.UrlReferrer.ToString();
                Response.Redirect(url, true);
                return View();
            }
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(String username, String password, Boolean rememberMe, String returnUrl)
        {
            ActionResult result = null;

            // TODO: Move this to install procedure.
            if(username == "admin" && password == "admin")
            {
                if (Membership.GetUser(username) == null)
                {
                    // TODO: Remove personal e-mail address.
                    Membership.CreateUser(username, password, "pj@born2code.net");
                }
                if (!Roles.IsUserInRole(username, MyShopRoles.Administrator))
                {
                    Roles.AddUserToRole(username, MyShopRoles.Administrator);
                }
            }

            if (Membership.ValidateUser(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, rememberMe);
            }

            if (!string.IsNullOrEmpty(returnUrl))
            {
                result = Redirect(returnUrl);
            }
            else
            {
                result = RedirectToAction("Index", "Home");
            }

            return result;
        }

        [Authorize(Roles = MyShopRoles.Administrator)]
        public ActionResult List()
        {
            // The Membership.GetAllUsers method doesn't return an
            // IEnumerable<MembershipUser> value, so we copy it to a
            // new list that does implement that required value.
            var users = Membership.GetAllUsers();
            var result = new MembershipUser[users.Count];
            users.CopyTo(result, 0);

            return View(result);
        }
    }
}