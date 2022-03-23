using System.ComponentModel.DataAnnotations;

namespace dndgenesis.Models
{
    public class Book
    {
        [Required]
        [Key]
        public int BookId { get; set; }

        [Required] 
        public string BookType { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public string PublishDate { get; set; }
    }
}
