using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Employee
    {
        // if this won't need to be serialized, consider
        // making the EmployeeID property setter private
        public int EmployeeID { get; set; }

        // don't forget to add a username
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LocalPhone { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public Employee() { } // default constructor

        public Employee(int employeeID,
                        // don't forget to add a username
                        string userName,
                        string firstName,
                        string lastName,
                        string localPhone,
                        string email,
                        bool active)
        {
            EmployeeID = employeeID;
            // don't forget to add a username
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            LocalPhone = localPhone;
            Email = email;
            active = Active;
        }
    }
}
