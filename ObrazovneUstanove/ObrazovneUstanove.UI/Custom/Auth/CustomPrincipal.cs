using System;
using System.Security.Principal;

namespace ObrazovneUstanove.UI.Custom.Auth
{
    internal interface ICustomPrincipal : IPrincipal
    {
        int KorisnikId { get; set; }
        int SkolaId { get; set; }
        string SkolaNaziv { get; set; }
        string[] Uloge { get; set; }
    }

    public class CustomPrincipal : ICustomPrincipal
    {
        public CustomPrincipal(string userName)
        {
            Identity = new GenericIdentity(userName);
        }

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            return false;
        }

        public int KorisnikId { get; set; }
        public int SkolaId { get; set; }
        public string SkolaNaziv { get; set; }
        public string[] Uloge { get; set; }
    }
}