using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObrazovneUstanove.UI.Models
{
    public class PrijavaIndexViewModel
    {
        public List<KorakViewModel> KorakViewModels { get; set; }
        public int PredmetId { get; set; }
        public bool ReadOnly { get; set; }
        public bool HideKrajButton { get; set; }
    }
}