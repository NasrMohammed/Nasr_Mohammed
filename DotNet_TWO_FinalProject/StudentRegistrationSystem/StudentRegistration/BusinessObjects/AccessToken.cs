using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessObjects
{
    public sealed class AccessToken : Student
    {
        public List<Role> Roles { get; private set; }

        public AccessToken(Student std, List<Role> roles)
        {
            if (std == null || roles == null || roles.Count == 0 || !std.Active)
            {
                throw new ApplicationException("Invalid Student");
            }
              base.UserID = std.UserID;
              base.UserName = std.UserName;
              base.MajorID = std.MajorID;
              base.FirstName = std.FirstName;
                base.LastName = std.LastName;              
                base.Phone = std.Phone;
                base.Address = std.Address;
                base.Email = std.Email;
                base.Active = std.Active;
            

            Roles = roles;
        }
    }
}
