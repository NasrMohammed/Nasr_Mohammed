using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BusinessObjects;

namespace BusinessLogic
{
    public class SecurityManager
    {
        const int MIN_USERNAME = 5;
        const int MIN_PASSWORD = 5;
        public static AccessToken ValidateExistingUser(string username, string password)
        {
            AccessToken accessToken;

            if (username.Length < MIN_USERNAME || password.Length < MIN_PASSWORD)
            {
                throw new ApplicationException("Invalid username or password.");
            }

            try
            {
                //if (1 == EmployeeAccessor.FindUserByUsernameAndPassword(username, password.HashSha256()))
                if (1 == StudentAccessor.FindUserByUsernameAndPassword(username, password.HashSha256()))

                {
                   // var emp = EmployeeAccessor.RetrieveUserByUsername(username);
                   // var roles = EmployeeAccessor.RetrieveRolesByEmployeeID(emp.EmployeeID);
                    var std = StudentAccessor.RetirveUserByUserName(username);
                    var roles = StudentAccessor.RetrieveRolesByStudentID(std.UserID);
                    accessToken = new AccessToken(std, roles);
                }
                else
                {
                    throw new ApplicationException("Data not found.");
                }
            }
            catch
            {
                throw;
            }
            return accessToken;
        }

        public static AccessToken ValidateNewUser(string username, string newPassword)
        {
            // check for new user
           // if (1 == EmployeeAccessor.FindUserByUsernameAndPassword(username, "NEWUSER"))
            if (1 == StudentAccessor.FindUserByUsernameAndPassword(username, "NEWUSER"))

            {
                //EmployeeAccessor.SetPasswordForUsername(username, "NEWUSER", newPassword.HashSha256());

                 StudentAccessor.SetPasswordForUsername(username, "NEWUSER", newPassword.HashSha256());
            }
            else
            {
                throw new ApplicationException("Data not found.");
            }

            return ValidateExistingUser(username, newPassword);
        }

    }
}
