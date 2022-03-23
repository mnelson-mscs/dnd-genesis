using System.ComponentModel.DataAnnotations;

namespace dndgenesis.Models
{
    public class SchoolMagic
    {
        [Required]
        [Key]
        public int SchoolMagicId { get; set; }

        public string SchoolMagicName { get; set; }



    }
}
