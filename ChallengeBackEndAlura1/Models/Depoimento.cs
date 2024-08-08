using System.ComponentModel.DataAnnotations;

namespace ChallengeBackEndAlura1.Models
{
    public class Depoimento
    {
        [Key]
        public int id { get; set; }
        public String foto { get; set; }
        [Required]
        public String depoimento { get; set; }
        [Required]
        public String nome { get; set; }
    }
}
