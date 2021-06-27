using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC_Demo.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [StringLength(50)]
        [Display(Name = "Author Name")]
        [Required]
        public string AuthorName { get; set; }
        public IList<Book> Books { get; set; }
    }
}
