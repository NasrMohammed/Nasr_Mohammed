using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EmployeeAccessor
    {

        public static Employee RetrieveUserByUsername(string username)
        // accepts a username, returns the corresponding employee object or a null reference
        {
            Employee employee;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_employee_with_username";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@username", username);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    employee = new Employee()
                    {
                        EmployeeID = reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        FirstName = reader.GetString(2),
                        LastName = reader.GetString(3),
                        LocalPhone = reader.GetString(4),
                        Email = reader.GetString(5),
                        Active = reader.GetBoolean(6)
                    };
                }
                else
                {
                    throw new ApplicationException("Data not found");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return employee;
        }

        public static List<Role> RetrieveRolesByEmployeeID(int employeeID)
        {
            var roles = new List<Role>();
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_roles_for_employeeID";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@employeeID", employeeID);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        roles.Add(new Role()
                        {
                            RoleName = reader.GetString(0),
                            RoleDescription = reader.GetString(1)
                        });
                    }
                }
                else
                {
                    throw new ApplicationException("Data not found");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return roles;
        }

        public static int FindUserByUsernameAndPassword(string username, string password)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_validate_active_username_and_password";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            try
            {
                conn.Open();
                count = (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return count;
        }

        public static int SetPasswordForUsername(string username, string oldPassword, string newPassword)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_update_password_for_username";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@oldPassword", oldPassword);
            cmd.Parameters.AddWithValue("@newPassword", newPassword);

            try
            {
                conn.Open();
                count = (int)cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return count;
        }

        public static List<Employee> FetchEmployeeList(Active recordType=Active.active)
        {
            // first, create the return object collection
            var employees = new List<Employee>();

            // get a connection from our connection object provider class
            var conn = DBConnection.GetDBConnection();

            // we need a query (known in ADO.NET as command text)
            string query = @"SELECT EmployeeID, UserName, FirstName, LastName, LocalPhone, Email, Active " +
                           @"FROM Employees ";
            if (recordType==Active.active)
            {
                query += @"WHERE active = 1 ";
            }
            else if (recordType==Active.inactive)
            {
                query += @"WHERE active = 0 ";
            }
            // if Active.all, we do nothing

            /*
                        int employeeID,
                        string userName  >>>>>>>>>>>>> don't forget this one
                        string firstName,
                        string lastName,
                        string localPhone,
                        string email,
                        bool active
             */

            // create a sqlcommand object
            var cmd = new SqlCommand(query, conn);

            // at this point, we need to worry about connection exceptions

            try
            {
                // open the connection
                conn.Open();

                // execute the command to return a SqlDataReader
                var reader = cmd.ExecuteReader();

                // trying to process the reader will throw exceptions if
                // it is empty, so we should check for rows
                if(reader.HasRows)
                {
                    // we can process the reader
                    while(reader.Read())
                    {
                        // we need to new up an employee
                        var currentEmployee = new Employee();
                        currentEmployee.EmployeeID = reader.GetInt32(0);    // employeeID
                        currentEmployee.UserName = reader.GetString(1);
                        currentEmployee.FirstName = reader.GetString(2);    // firstName
                        currentEmployee.LastName = reader.GetString(3);     // lastName
                        currentEmployee.LocalPhone = reader.IsDBNull(4) ? "" : reader.GetString(4);   // localphone
                        currentEmployee.Email = reader.IsDBNull(5) ? "" : reader.GetString(5) ?? "";        // email
                        currentEmployee.Active = reader.GetBoolean(6);      // active

                        //var currentEmployee = new Employee()
                        //{
                        //    EmployeeID = reader.GetInt32(0),
                        //    FirstName = reader.GetString(1),
                        //    LastName = reader.GetString(2),
                        //    LocalPhone = reader.GetString(3),
                        //    Email = reader.GetString(4),
                        //    Active = reader.GetBoolean(5)
                        //};
                        
                        // add the currentEmployee to the list
                        employees.Add(currentEmployee);
                    }
                }
                else
                {
                    // this would be a place to throw an application exception if we
                    // did not want to return an empty List<Employee>
                    throw new ApplicationException("Your query returned no data.");
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            // if the query does not succeed, this will be empty...
            return employees;
        }
    
        public static int FetchEmployeeCount(Active recordType=Active.active)
        {
            int recordCount = 0;

            // get a connection
            var conn = DBConnection.GetDBConnection();

            // create command text
            string cmdText = @"SELECT COUNT(*) " +
                     @"FROM Employees ";

            if( recordType==Active.active)
            {
                cmdText += @"WHERE Active = 1 ";
            }
            else if (recordType==Active.inactive)
            {
                cmdText += @"WHERE Active = 0 ";
            }

            // create a command object
            var cmd = new SqlCommand(cmdText, conn);

            try
            {
                conn.Open();
                recordCount = (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return recordCount;
        }
    
        public static int UpdateEmployeeEmail(int employeeID, string newEmail)
        {
            int rowCount = 0;

            // get a connection
            var conn = DBConnection.GetDBConnection();

            // we need a command object (the command text is in the stored procedure)
            var cmd = new SqlCommand("sp_update_employee_email", conn);

            // set the command type for stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // we need to manually add any input or output parameters
            cmd.Parameters.Add(new SqlParameter("EmployeeID", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("Email", SqlDbType.VarChar, 100));

            cmd.Parameters["EmployeeID"].Value = employeeID;
            cmd.Parameters["Email"].Value = newEmail;

            cmd.Parameters.Add(new SqlParameter("RowCount", SqlDbType.Int));
            cmd.Parameters["RowCount"].Direction = ParameterDirection.ReturnValue;

            try
            {
                conn.Open();
                rowCount = (int)cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rowCount;
        }
    
        public static int InsertEmployee(Employee emp)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetDBConnection();

            string cmdText = @"INSERT INTO Employees " +
                         @"(FirstName, LastName, LocalPhone, Email) " +
                         @"VALUES " +
                         @"('" + emp.FirstName + "', '" + emp.LastName + 
                            "', '" + emp.LocalPhone + "', '" + emp.Email + "') ";

            var cmd = new SqlCommand(cmdText, conn);

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                
                throw;
            }
            finally 
            {
                conn.Close();
            }


            return rowsAffected;
        }

    }
}
