﻿using System.ComponentModel.DataAnnotations;

namespace ObrazovneUstanove.UI.Models
{
    public class StepOneViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}