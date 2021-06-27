using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC_Demo.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [StringLength(50)]
        [Display(Name = "Author Name")]
        [Required]
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = ("Year Published"))]
        public DateTime DateOfPublishing { get; set; }
    }
}
