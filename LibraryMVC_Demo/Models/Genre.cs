using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC_Demo.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [StringLength(50)]
        [Display(Name = "Genre")]
        [Required]
        public string Name { get; set; }
        public IList<Book> Books { get; set; }
    }
}
