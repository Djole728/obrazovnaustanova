using ObrazovneUstanove.UI.Custom.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ObrazovneUstanove.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Bootstrapper.Configure();
        }

        void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var ctx = HttpContext.Current;
            if (ctx.Request.IsAuthenticated)
            {
                ICookieResolver CookieResolver = DependencyResolver.Current.GetService<ICookieResolver>();
                var cookie = CookieResolver.Get();

                if (cookie != null)
                {
                    var newUser = new GenericPrincipal(ctx.User.Identity, cookie.Uloge);
                    ctx.User = Thread.CurrentPrincipal = newUser;
                }
            }
        }
    }
}
