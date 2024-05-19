using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDBWebService.Models
{
    public class Movies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? MaleLead { get; set; }
        public string? FemaleLead { get; set; }

        [Required]
        public int Rating { get; set; }
        [Required]
        public int Budget { get; set; }

        public ICollection<Actor> Actors { get; set; }

    }
}
