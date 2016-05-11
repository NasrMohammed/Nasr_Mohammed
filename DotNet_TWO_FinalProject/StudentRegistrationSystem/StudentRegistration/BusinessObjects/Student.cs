using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Student
    {

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string MajorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }       
        public string Email { get; set; }
        public bool Active { get; set; }
        
        public Student() { } // default constructor

        public Student(int userID,                        
                        string userName,
                        string majorID,
                        string firstName,
                        string lastName,
                        string phone,
                        string address,                    
                        string email,
                        bool active
                         )
                       
        {
            UserID = userID;
             UserName = userName;
             MajorID = majorID;
             FirstName = firstName;
             LastName = lastName;            
             Phone = phone;           
             Address = address;
             Email = email;
             Active = active;
              
        }
    }
}
