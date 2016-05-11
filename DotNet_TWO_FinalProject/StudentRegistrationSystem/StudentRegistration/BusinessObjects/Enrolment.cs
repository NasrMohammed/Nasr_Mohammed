using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Enrolment
    {
        public string EnrolmentID { get; set; }
        public int UserID { get; set; }
        public string ClassID { get; set; }
        public string SectionID { get; set; }
       

        public Enrolment() { } // default constructor

        public Enrolment(string enrolmentID,
                        int userID,
                        string classID,
                        string sectionID
                        
                        )                      
        {
            EnrolmentID = EnrolmentID;
            UserID = userID;
            ClassID = classID;
            SectionID = sectionID;
           
                                      
        }
    }
}
