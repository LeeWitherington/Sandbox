using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using log4net;
using MyShop.Commands.VisitorCommands;
using MyShop.Commands;
using Ncqrs.Commands;

namespace MyShop.UI.Web.MainSite.Core.Mvc
{
    public class RegisterVisitAttribute : ActionFilterAttribute, IActionFilter
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public const String VisitorIdentifierKey = "MyShopVisitorIdentifier";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var commands = new List<ICommand>(1);

            // Call base first.
            base.OnActionExecuting(filterContext);

            if(filterContext.HttpContext.Request.HttpMethod != "GET")
            {
                Log.DebugFormat("Skipped visit registion since http method was not GET (actual value was: {0}).", filterContext.HttpContext.Request.HttpMethod);
                return;
            }

            Log.DebugFormat("Registering visit for:\r\n\tsession id: {0}\r\n\turl: {1}", filterContext.HttpContext.Session.LCID, filterContext.HttpContext.Request.HttpMethod + " " + filterContext.HttpContext.Request.Url);

            var context = filterContext.HttpContext;
            var requestCookies = context.Request.Cookies;
            var responseCookies = context.Response.Cookies;

            if (requestCookies != null)
            {
                // Get identifier.
                Guid visitorId = Guid.Empty;

                // Get cookie and if exists, get value.
                var identifierCookie = requestCookies[VisitorIdentifierKey];
                if (identifierCookie != null)
                {
                    var cookieValue = identifierCookie.Value;

                    if (!String.IsNullOrEmpty(cookieValue))
                    {
                        try
                        {
                            visitorId = new Guid(cookieValue);
                        }
                        catch (FormatException)
                        {
                            Log.WarnFormat("Cookie value '{0}' not a valid guid.", cookieValue);
                        }
                        catch(OverflowException)
                        {
                            Log.WarnFormat("Cookie value '{0}' not a valid guid.", cookieValue);    
                        }
                    }
                }

                // If there is no identifier found.
                if (visitorId == Guid.Empty)
                {
                    // Create new identifier and persist into a cookie.
                    visitorId = Guid.NewGuid();
                    var visitorIdAsString = visitorId.ToString();
                    identifierCookie = new HttpCookie(VisitorIdentifierKey, visitorIdAsString);
                    responseCookies.Set(identifierCookie);

                    // Add new visit.
                    var addNewVisitorCommand = new AddNewVisitor(visitorId);
                    commands.Add(addNewVisitorCommand);
                }

                // Register visit.
                var visitCommand = new RegisterVisit(visitorId, context.Request.Url.AbsoluteUri, context.Request.UserHostAddress);
                commands.Add(visitCommand);

                // Publish commands.
                MyShopWebApplication.CommandService.Execute(commands);
            }
        }
    }
}
