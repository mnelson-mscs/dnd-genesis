using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dndgenesis.Models
{
    public class DndClass
    {
        [Required]
        [Key]
        public int DndClassId { get; set; }

        [Required]
        public string DndClassName { get; set; }

        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }

        [Required]
        public string HitDice { get; set; }
    }
}