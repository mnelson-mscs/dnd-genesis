using System.ComponentModel.DataAnnotations;

namespace dndgenesis.Models
{
    public class Race
    {
        [Required]
        [Key]
        public int RaceId { get; set; }

        [Required]
        public string RaceName { get; set; }
    }
}
