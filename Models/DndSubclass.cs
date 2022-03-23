using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dndgenesis.Models
{
    public class DndSubclass
    {
        [Required]
        [Key]
        public int DndSubclassId { get; set; }

        [Required]
        [ForeignKey("DndClass")]
        public int DndClassId { get; set; }

        public DndClass DndClass { get; set; }

        [Required]
        public string DndSubclassName { get; set; }
    }
}