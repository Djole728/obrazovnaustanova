using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObrazovneUstanove.UI.Models
{
    public class TestViewModel
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public List<KorisnikViewModel> TestKorisnik { get; set; }
    }
}