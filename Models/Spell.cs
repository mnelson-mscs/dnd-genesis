using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dndgenesis.Models
{
    public class Spell
    {
        [Required]
        [Key]
        public int SpellId { get; set; }

        public string SpellName { get; set; }

        public int Level { get; set; }

        //public bool Ritual { get; set; }

        //public string CastingTime { get; set; }

        //public bool Concentration { get; set; }

        //public string Range { get; set; }

        //public string Components { get; set; }

        //public string Duration { get; set; }

        [Required]
        [ForeignKey("SchoolMagic")]
        public int SchoolMagicId { get; set; }
        public SchoolMagic SchoolMagic { get; set; }

        [Required]
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
