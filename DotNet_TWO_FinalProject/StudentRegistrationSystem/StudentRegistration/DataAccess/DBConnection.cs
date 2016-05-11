using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess
{
    internal class DBConnection
    {
        const string ConnectionString = @"Data Source= localhost;Initial Catalog=StudentRegistrationSystem;Integrated Security=True";
        
        public static SqlConnection getDBConnection() // only accessible by DA classes
        {
            return new SqlConnection(ConnectionString);
        }

    }
}
