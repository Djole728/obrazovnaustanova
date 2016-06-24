using System;
using System.ComponentModel.DataAnnotations;

namespace ObrazovneUstanove.UI.Models
{
    public class KorisnikViewModel
    {
        public int KorisnikId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Ime { get; set; }
        [Required]
        [MaxLength(200)]
        public string Prezime { get; set; }
        [Required]
        [MaxLength(200)]
        public string ImeJednogRoditelja { get; set; }
        [Required]
        [MinLength(13),MaxLength(13)]
        public string Jmb { get; set; }
        [Required]
        public string Pol { get; set; }
        [Required]
        public DateTime DatumRodjenja { get; set; }
        [Required]
        public int MjestoRodjenjaOpstinaId { get; set; }
        [Required]
        public int PrebivalisteNaseljenoMjestoId { get; set; }
        [Required]
        public short StrucnaSpremaId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Zanimanje { get; set; }
    }
}