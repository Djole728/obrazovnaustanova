using System;
namespace ObrazovneUstanove.UI.Custom.Auth
{
    public class CustomPrincipalSerializeModel
    {
        public int KorisnikId { get; set; }
        public int SkolaId { get; set; }
        public string SkolaNaziv { get; set; }
        public string[] Uloge { get; set; }
    }
}