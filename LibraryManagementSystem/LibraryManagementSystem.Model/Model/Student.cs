using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model.Model
{
    public class Student
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Student ID is requred"), Display(Name = "Student ID")]
        [StringLength(50, MinimumLength = 3)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(150, MinimumLength = 3)]
        public string Address { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact No is required")]
        public string Contact { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        public byte[] Data { get; set; }


    }
}
