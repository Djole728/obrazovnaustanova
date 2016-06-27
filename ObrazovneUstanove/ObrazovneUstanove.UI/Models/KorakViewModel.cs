using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObrazovneUstanove.UI.Models
{
    public class KorakViewModel
    {
        public byte KorakId { get; set; }
        public byte RedniBroj { get; set; }
        public string Naziv { get; set; }
        public string Url { get; set; }
        public bool SkipPost { get; set; }

        public override bool Equals(object obj)
        {
            var self = this;
            var other = obj as KorakViewModel;
            return self.KorakId == other.KorakId;
        }
        public override int GetHashCode()
        {
            return this.KorakId;
        }
    }
}