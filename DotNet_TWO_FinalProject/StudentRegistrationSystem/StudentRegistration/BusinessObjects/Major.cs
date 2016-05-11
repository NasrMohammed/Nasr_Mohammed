using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Major
    {
        public string MajorID { get; set; }
        public string MajorName { get; set; }       
        
        
        public Major() { } // default constructor

        public Major(string majorID,
                     string majorName)                      
                        
                       
        {
            MajorID = majorID;
            MajorName = majorName;
              
        }
    }
}
