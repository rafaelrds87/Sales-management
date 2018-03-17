using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace WebApplication3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            // obtem o cookie
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                // se o cookie tiver algum valor
                if (!string.IsNullOrEmpty(authCookie.Value))
                {
                    // remove a criptografia do cookie
                    var authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                    // se deu certo a decriptografia e o cookie nao expirou
                    if (authTicket != null && !authTicket.Expired)
                    {
                        // obtem os dados do usuario
                        var roles = authTicket.UserData.Split(',');

                        var principal  = new GenericPrincipal(new FormsIdentity(authTicket), roles);

                        // define um objeto de usuario no contexto da aplicacao
                        HttpContext.Current.User = principal;
                        System.Threading.Thread.CurrentPrincipal = principal;
                    }
                }
            }
        }
    }
}
