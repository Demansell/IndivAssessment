﻿using System.ComponentModel.DataAnnotations;

namespace IndivAssessment.Models
{
    public class SongGenre
    {
        public int Id { get; set; }
        [Required]
        public int SongId { get; set; }
        public int GenreId { get; set; }
    }
}
