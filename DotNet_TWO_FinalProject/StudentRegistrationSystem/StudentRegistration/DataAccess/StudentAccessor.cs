using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class StudentAccessor
    {
        public static Student RetirveUserByUserName(string username)
        {
            Student student;
            var conn = DBConnection.getDBConnection();
            var query = @"sp_select_user_with_username";
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
                    student = new Student()
                    {
                        UserID = reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        MajorID = reader.GetString(2),
                        FirstName = reader.GetString(3),
                        LastName = reader.GetString(4),
                        Phone = reader.GetString(5),
                        Address = reader.GetString(6),
                        Email = reader.GetString(7),
                        Active = reader.GetBoolean(8)
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
            return student;
        }
        public static List<Student> FetchStudentList(Active recordType = Active.active)
        {
            // first, create the return object collection
            var students = new List<Student>();

            // get a connection from our connection object provider class
            var conn = DBConnection.getDBConnection();

            // we need a query (known in ADO.NET as command text)
            string query = @"SELECT UserID, UserName,  MajorID, FirstName, LastName, Phone, Address, Email, Active " +               
                           @"FROM Users ";
                          
            if (recordType == Active.active)
            {
                query += @"WHERE active = 1 ";
            }
            else if (recordType == Active.inactive)
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
                if (reader.HasRows)
                {
                    // we can process the reader
                    while (reader.Read())
                    {
                        // we need to new up an employee
                        var currentStudent = new Student();
                        currentStudent.UserID = reader.GetInt32(0);
                        currentStudent.UserName = reader.GetString(1);
                        currentStudent.MajorID = reader.GetString(2);     
                        currentStudent.FirstName = reader.GetString(3);
                        currentStudent.LastName = reader.GetString(4);
                        currentStudent.Phone = reader.GetString(5);
                        currentStudent.Address = reader.GetString(6);
                        currentStudent.Email = reader.GetString(7);
                        currentStudent.Active = reader.GetBoolean(8);
                       
                        

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
                        students.Add(currentStudent);
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
            return students;
        }
        public static List<Role> RetrieveRolesByStudentID(int userID)
        {
            var roles = new List<Role>();
            var conn = DBConnection.getDBConnection();
            var query = @"sp_select_roles_for_UserID";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@userID", userID);
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
        public static int FetchStudentCount(Active recordType = Active.active)
        {
            int recordCount = 0;

            // get a connection
            var conn = DBConnection.getDBConnection();

            // create command text
            string cmdText = @"SELECT COUNT(*) " +
                     @"FROM Users ";

            if (recordType == Active.active)
            {
                cmdText += @"WHERE Active = 1 ";
            }
            else if (recordType == Active.inactive)
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
        public static int UpdateStudentRecord(int userID, string userName,  string firstName, string lastName, string phone, string address, string newEmail)
        {
            int rowCount = 0;

            // get a connection
            var conn = DBConnection.getDBConnection();

            // we need a command object (the command text is in the stored procedure)
            var cmd = new SqlCommand("sp_update_user_record", conn);

            // set the command type for stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // we need to manually add any input or output parameters
            cmd.Parameters.Add(new SqlParameter("userID", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("UserName", SqlDbType.VarChar, 50));
            cmd.Parameters.Add(new SqlParameter("FirstName", SqlDbType.VarChar, 100));
            cmd.Parameters.Add(new SqlParameter("LastName", SqlDbType.VarChar, 100));
            cmd.Parameters.Add(new SqlParameter("Phone", SqlDbType.VarChar, 10));
            cmd.Parameters.Add(new SqlParameter("Address", SqlDbType.VarChar, 100));
            cmd.Parameters.Add(new SqlParameter("Email", SqlDbType.VarChar, 100));

            cmd.Parameters["userID"].Value = userID;
            cmd.Parameters["UserName"].Value = userName;
            cmd.Parameters["FirstName"].Value = firstName;
            cmd.Parameters["LastName"].Value = lastName;
            cmd.Parameters["Phone"].Value = phone;
            cmd.Parameters["Address"].Value = address;
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
        public static int DeleteStudentRecord(int userID)
        {
            int rowCount = 0;

            // get a connection
            var conn = DBConnection.getDBConnection();

            // we need a command object (the command text is in the stored procedure)
            var cmd = new SqlCommand("sp_delete_user_record", conn);

            // set the command type for stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // we need to manually add any input or output parameters
            cmd.Parameters.Add(new SqlParameter("userID", SqlDbType.Int));
           

            cmd.Parameters["userID"].Value = userID;
            

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

        public static int InsertStudent(Student std)
        {
            int rowsAffected = 0;

            var conn = DBConnection.getDBConnection();
            
            string cmdText = @"INSERT INTO Users " +
                         @"(UserName, MajorID, FirstName, LastName, Phone, Address, Email) " +
                         @"VALUES " +
                         @"( '" + std.UserName + "' ,'" + std.MajorID + "' ,'" + std.FirstName + "' ,'" + std.LastName  +
                            "', '" + std.Phone + "', '" +  std.Email + "', '"  + std.Address + "') ";

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
        public static int FindUserByUsernameAndPassword(string username, string password)
        {
            int count = 0;
            var conn = DBConnection.getDBConnection();
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
            var conn = DBConnection.getDBConnection();
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
        public static int InsertMajors(Major mjr)
        {
            int rowsAffected = 0;

            var conn = DBConnection.getDBConnection();

            string cmdText = @"INSERT INTO Majors " +
                         @"( MajorID, MajorName) " +
                         @"VALUES " +
                         @"( '" + mjr.MajorID + "' ,'" + mjr.MajorName + "') ";

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
        public static int InsertClass(Classes cls)
        {
            int rowsAffected = 0;

            var conn = DBConnection.getDBConnection();

            string cmdText = @"INSERT INTO Classes " +
                         @"( ClassID, DepartmentID, Description, NumOfSeats, ClassName) " +
                         @"VALUES " +
                         @"( '" + cls.ClassID + "' ,'" + cls.DepartmentID + "' ,'" + cls.Description + "' ,'" + cls.NumOfSeats + "' ,'" + cls.ClassName + "') ";

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
        public static List<Major> FetchMajorList()
        {
            // first, create the return object collection
            var mjr = new List<Major>();

            // get a connection from our connection object provider class
            var conn = DBConnection.getDBConnection();

            // we need a query (known in ADO.NET as command text)
            string query = @"SELECT MajorID, MajorName " +
                           @"FROM Majors ";

           
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
                if (reader.HasRows)
                {
                    // we can process the reader
                    while (reader.Read())
                    {
                        // we need to new up an employee
                        var currentMjr = new Major();
                        currentMjr.MajorID = reader.GetString(0);
                        currentMjr.MajorName = reader.GetString(1);
                        



                        
                        mjr.Add(currentMjr);
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
            return mjr;  
        }
        public static List<Classes> FetchClassList()
        {
            // first, create the return object collection
            var cls = new List<Classes>();

            // get a connection from our connection object provider class
            var conn = DBConnection.getDBConnection();

            // we need a query (known in ADO.NET as command text)
            string query = @"SELECT ClassID, DepartmentID, Description, NumOfSeats, ClassName " +
                           @"FROM Classes ";


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
                if (reader.HasRows)
                {
                    // we can process the reader
                    while (reader.Read())
                    {
                        // we need to new up an employee
                        var currentCls = new Classes();
                        currentCls.ClassID = reader.GetString(0);
                        currentCls.DepartmentID = reader.GetString(1);
                        currentCls.Description = reader.GetString(2);
                        currentCls.NumOfSeats = reader.GetString(3);
                        currentCls.ClassName = reader.GetString(4);




                        cls.Add(currentCls);
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
            return cls;
        }
        public static int InsertDepartment(Department dpr)
        {
            int rowsAffected = 0;

            var conn = DBConnection.getDBConnection();

            string cmdText = @"INSERT INTO Departments " +
                         @"( DepartmentID, DepartmentName) " +
                         @"VALUES " +
                         @"( '" + dpr.DepartmentID + "' ,'" + dpr.DepartmentName  + "') ";

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
        public static List<Department> FetchDepartmentList()
        {
            // first, create the return object collection
            var dpr = new List<Department>();

            // get a connection from our connection object provider class
            var conn = DBConnection.getDBConnection();

            // we need a query (known in ADO.NET as command text)
            string query = @"SELECT DepartmentID, DepartmentName " +
                           @"FROM Departments ";


            // create a sqlcommand object
            var cmd = new SqlCommand(query, conn);


            try
            {
                // open the connection
                conn.Open();

                // execute the command to return a SqlDataReader
                var reader = cmd.ExecuteReader();

                // trying to process the reader will throw exceptions if
                // it is empty, so we should check for rows
                if (reader.HasRows)
                {
                    // we can process the reader
                    while (reader.Read())
                    {
                        // we need to new up an employee
                        var currentDpr = new Department();
                        currentDpr.DepartmentID = reader.GetString(0);
                        currentDpr.DepartmentName = reader.GetString(1);
                        
                        dpr.Add(currentDpr);
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
            return dpr;
        }
        public static int InsertSection(Section sec)
        {
            int rowsAffected = 0;

            var conn = DBConnection.getDBConnection();

            string cmdText = @"INSERT INTO Sections " +
                         @"( SectionID, UserID, TermID, LocationID) " +
                         @"VALUES " +
                         @"( '" + sec.SectionID + "' ,'" + sec.UserID + "' ,'" + sec.TermID + "' ,'" + sec.LocationID + "' ) ";

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
        public static List<Section> FetchSectionList()
        {
            // first, create the return object collection
            var sec = new List<Section>();

            // get a connection from our connection object provider class
            var conn = DBConnection.getDBConnection();

            // we need a query (known in ADO.NET as command text)
            string query = @"SELECT SectionID, UserID, TermID, LocationID " +
                           @"FROM Sections ";


            // create a sqlcommand object
            var cmd = new SqlCommand(query, conn);


            try
            {
                // open the connection
                conn.Open();

                // execute the command to return a SqlDataReader
                var reader = cmd.ExecuteReader();

                // trying to process the reader will throw exceptions if
                // it is empty, so we should check for rows
                if (reader.HasRows)
                {
                    // we can process the reader
                    while (reader.Read())
                    {
                        // we need to new up an employee
                        var currentSec = new Section();
                        currentSec.SectionID = reader.GetString(0);
                        currentSec.UserID = reader.GetInt32(1);
                        currentSec.TermID = reader.GetString(2);
                        currentSec.LocationID = reader.GetString(3);
                       
                        sec.Add(currentSec);
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
            return sec;
        }
        public static int InsertLocation(Location loc)
        {
            int rowsAffected = 0;

            var conn = DBConnection.getDBConnection();

            string cmdText = @"INSERT INTO Locations " +
                         @"(LocationID, LocationName) " +
                         @"VALUES " +
                         @"( '" + loc.LocationID + "' ,'" + loc.LocationName + "' ) ";

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
        public static List<Location> FetchLocationList()
        {
            // first, create the return object collection
            var loc = new List<Location>();

            // get a connection from our connection object provider class
            var conn = DBConnection.getDBConnection();

            // we need a query (known in ADO.NET as command text)
            string query = @"SELECT LocationID, LocationName " +
                           @"FROM Locations ";


            // create a sqlcommand object
            var cmd = new SqlCommand(query, conn);


            try
            {
                // open the connection
                conn.Open();

                // execute the command to return a SqlDataReader
                var reader = cmd.ExecuteReader();

                // trying to process the reader will throw exceptions if
                // it is empty, so we should check for rows
                if (reader.HasRows)
                {
                    // we can process the reader
                    while (reader.Read())
                    {
                        // we need to new up an employee
                        var currentLoc = new Location();
                        currentLoc.LocationID = reader.GetString(0);
                        currentLoc.LocationName = reader.GetString(1);

                        loc.Add(currentLoc);
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
            return loc;
        }
        public static int InsertEnrolment(Enrolment enr)
        {
            int rowsAffected = 0;

            var conn = DBConnection.getDBConnection();

            string cmdText = @"INSERT INTO Enrolments " +
                         @"(EnrolmentID, UserID, ClassID, SectionID) " +
                         @"VALUES " +
                         @"( '" + enr.EnrolmentID + "' ,'" + enr.UserID + "' , '" + enr.ClassID + "' ,'" + enr.SectionID + "' ) ";

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
        public static List<Enrolment> FetchEnrolmentList()
        {
            // first, create the return object collection
            var enr = new List<Enrolment>();

            // get a connection from our connection object provider class
            var conn = DBConnection.getDBConnection();

            // we need a query (known in ADO.NET as command text)
            string query = @"SELECT EnrolmentID, UserID, ClassID, SectionID " +
                           @"FROM Enrolments ";


            // create a sqlcommand object
            var cmd = new SqlCommand(query, conn);


            try
            {
                // open the connection
                conn.Open();

                // execute the command to return a SqlDataReader
                var reader = cmd.ExecuteReader();

                // trying to process the reader will throw exceptions if
                // it is empty, so we should check for rows
                if (reader.HasRows)
                {
                    // we can process the reader
                    while (reader.Read())
                    {
                        // we need to new up an employee
                        var currentEnr = new Enrolment();
                        currentEnr.EnrolmentID = reader.GetString(0);
                        currentEnr.UserID = reader.GetInt32(1);
                        currentEnr.ClassID = reader.GetString(2);
                        currentEnr.SectionID = reader.GetString(3);

                        enr.Add(currentEnr);
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
            return enr;
        }

    }
}
