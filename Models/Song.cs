using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace IndivAssessment.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        //public string? Artist { get; set; }
        public int? ArtistId { get; set; }
        public string? Album { get; set; }
        public int? Length { get; set; }

        //Uncomment these out to try and hit MVP 
        //public List<Genre> Genres { get; set; }
        //public List<Artist> Artists { get; set; }
    }

}
