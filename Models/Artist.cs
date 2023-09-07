﻿using System.ComponentModel.DataAnnotations;

namespace IndivAssessment.Models
{
    public class Artist
    {
        public int? Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Bio { get; set; }

        //public List<Song>? Songs { get; set; }
    }
}
