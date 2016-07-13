using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ObrazovneUstanove.UI.Models
{
    public class ObrazovneUstanoveLoginViewModel
    {
        [Required(ErrorMessage = "Polje {0} je obavezno!")]
        [DisplayName("Korisničko ime")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Polje {0} je obavezno!")]
        [DisplayName("Lozinka")]
        public string Password { get; set; }
    }
}