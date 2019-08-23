using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model.Model
{
    public class Order
    {
        public int ID { get; set; }

        [Required]
        public int DayFor { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        public int IsReturn { get; set; }

        [Required]
        public int StudentID { get; set; }
        public Student Student { get; set; }

        [Required]
        public int BookID { get; set; }
        public virtual Book Book { get; set; }

        [NotMapped]
        public int sID { get; set; }

        [NotMapped]
        public int bID { get; set; }

        [NotMapped]
        public string scode { get; set; }

        [NotMapped]
        public string bcode { get; set; }


        [NotMapped]
        public string bName { get; set; }

        [NotMapped]
        public string bAuthonerName { get; set; }

      
                                






    }
}
