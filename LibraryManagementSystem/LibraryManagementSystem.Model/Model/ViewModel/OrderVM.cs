using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model.Model.ViewModel
{
    public class OrderVM
    {
        [NotMapped]
        public int oID { get; set; }
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
        public string sName { get; set; }
        
        [NotMapped]
        public string bAuthonerName { get; set; }
        [NotMapped]
        public int oDayFor { get; set; }
        [NotMapped]
        public DateTime oDate { get; set; }
        [NotMapped]
        public DateTime OReturnDate { get; set; }
        [NotMapped]
        public int oIsReturn { get; set; }
    }
}
