﻿using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Wagering.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NormalizedName { get; set; }
    }
}
