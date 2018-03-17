using System;
using System.Web;
using System.Web.Security;

namespace WebApplication3.Libs
{
    public static class Auth
    {
        public static void LogIn(string userName, string userData)
        {
            FormsAuthentication.Initialize();

            var expiration = DateTime.Now.Add(FormsAuthentication.Timeout);

            var authTicket = new FormsAuthenticationTicket(
                1,
                userName,
                DateTime.Now,
                expiration,
                true,
                userData);

            string encTicket = FormsAuthentication.Encrypt(authTicket);

            if (!FormsAuthentication.CookiesSupported)
            {
                FormsAuthentication.SetAuthCookie(encTicket, true);
            }
            else
            {
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket)
                {
                    Expires = authTicket.Expiration
                };

                HttpContext.Current.Response.Cookies.Add(authCookie);
            }
        }

        public static void LogOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}