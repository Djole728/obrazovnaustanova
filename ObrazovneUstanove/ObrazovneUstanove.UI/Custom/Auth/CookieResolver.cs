using ObrazovneUstanove.Domain;
using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace ObrazovneUstanove.UI.Custom.Auth
{
    public class CookieResolver : ICookieResolver
    {
        public CustomPrincipal Get()
        {
            CustomPrincipal customPrincipal = null;

            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                var serializer = new JavaScriptSerializer();

                var serializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(authTicket.UserData);

                customPrincipal = new CustomPrincipal(authTicket.Name)
                {
                    KorisnikId = serializeModel.KorisnikId,
                    SkolaId = serializeModel.SkolaId,
                    SkolaNaziv = serializeModel.SkolaNaziv,
                    Uloge = serializeModel.Uloge,
                };
            }

            return customPrincipal;
        }

        public void Set(string userName, Korisnik korisnik)
        {
            var serializeModel = new CustomPrincipalSerializeModel
            {
                KorisnikId = korisnik.KorisnikId,
                SkolaId = 1,
                SkolaNaziv = "Test",
                Uloge = new string[5]
            };


            var serializer = new JavaScriptSerializer();

            var userData = serializer.Serialize(serializeModel);

            var authTicket = new FormsAuthenticationTicket(
                1,
               userName,
                DateTime.Now,
                DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
                false,
                userData);

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            HttpContext.Current.Response.Cookies.Add(faCookie);
        }

        public void Remove()
        {
            FormsAuthentication.SignOut();
        }
    }

    public interface ICookieResolver
    {
        CustomPrincipal Get();
        void Set(string userName, Korisnik korisnik);
        void Remove();
    }
}