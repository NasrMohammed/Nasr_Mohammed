using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Term
    {
        public string TermID { get; set; }
        public string TermName { get; set; }       
        
        
        public Term() { } // default constructor

        public Term(string termID,
                         string termName)                      
                        
                       
        {
            TermID = termID;
            TermName = termName;
              
        }
    }
}
