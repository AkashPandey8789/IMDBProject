using System.ComponentModel.DataAnnotations.Schema;

namespace IMDBWebService.Models
{
    public class Actor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public ICollection<Movies> Movies { get; set; }
    }
}
