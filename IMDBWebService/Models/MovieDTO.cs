using System.ComponentModel.DataAnnotations;

namespace IMDBWebService.Models
{
    public class MovieDTO
    {
        public string Title { get; set; }
        public string? MaleLead { get; set; }
        public string? FemaleLead { get; set; }

        [Required]
        public int Rating { get; set; }
        [Required]
        public int Budget { get; set; }

        public ICollection<ActorDTO> Actors { get; set; }
    }
}
