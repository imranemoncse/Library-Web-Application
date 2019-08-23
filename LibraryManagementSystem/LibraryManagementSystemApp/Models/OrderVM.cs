using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemApp.Models
{
    public class OrderVM
    {

    
        public int oID { get; set; }
    
        public int sID { get; set; }
        
        public int bID { get; set; }
       
        public string scode { get; set; }
     
        public string bcode { get; set; }
     
        public string bName { get; set; }
        
        public string bAuthonerName { get; set; }
       
        public int oDayFor { get; set; }
       
        public DateTime oDate { get; set; }
        
        public DateTime OReturnDate { get; set; }
       
        public int oIsReturn { get; set; }
    }
}