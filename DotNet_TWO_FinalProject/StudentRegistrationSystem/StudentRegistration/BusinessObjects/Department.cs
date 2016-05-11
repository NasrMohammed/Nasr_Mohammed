using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Department
    {
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }       
        
        
        public Department() { } // default constructor

        public Department(string departmentID,                        
                         string departmentName)                      
                        
                       
        {
            DepartmentID = departmentID;
            DepartmentName = departmentName;
              
        }
    }
}
