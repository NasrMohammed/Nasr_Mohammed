using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Classes
    {
        public string ClassID { get; set; }
        public string DepartmentID { get; set; }
        public string Description { get; set; }
        public string NumOfSeats { get; set; }
        public string ClassName { get; set; }

        public Classes() { } // default constructor

        public Classes(   string classID,
                        string departmentID,
                        string description,
                        string numOfSeats,
                        string className
                        )                      
        {
            ClassID = classID;
            DepartmentID = departmentID;
            Description = description;
            NumOfSeats = numOfSeats;
            ClassName = className;
                              
        }

    }
}
