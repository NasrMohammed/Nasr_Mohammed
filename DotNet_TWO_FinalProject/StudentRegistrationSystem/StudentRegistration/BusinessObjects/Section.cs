using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Section
    {
        public string SectionID { get; set; }
        public int UserID { get; set; }
        public string TermID { get; set; }
        public string LocationID { get; set; }      

        public Section() { } // default constructor

        public Section(string sectionID,
                        int userID,
                        string termID,
                        string locationID
                        )                      
        {
            SectionID = sectionID;
            UserID = userID;
            TermID = termID;
            LocationID = locationID;
                                      
        }
    }
}
