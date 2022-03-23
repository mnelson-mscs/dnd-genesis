using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dndgenesis.Models
{
    public class Subrace
    {
        [Required]
        [Key]
        public int SubraceId { get; set; }

        public string SubraceName { get; set; }

        [Required]
        [ForeignKey("Race")]
        public int RaceId { get; set; }
        public Race Race { get; set; }

        public string AbilityScores { get; set; }

        //public string Size { get; set; }

        //public string Age { get; set; }

        //public string Speed { get; set; }

        [Required]
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
