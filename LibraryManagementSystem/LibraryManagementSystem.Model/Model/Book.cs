using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model.Model
{
    public class Book
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Book ID is required"), Display(Name = "Book ID")]
        [StringLength(50, MinimumLength = 3)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Author name is required"), Display(Name = "Author Name")]
        [StringLength(150, MinimumLength = 3)]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Quantity is Required")]
        public int Quantity { get; set; }
        

        public byte[] Data { get; set; }
    }
}
