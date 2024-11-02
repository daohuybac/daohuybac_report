using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class DBConnection
    {
        public DBConnection()
        { 
        }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=FALLEN\SQLEXPRESS; Initial Catalog=dhbawsc; User Id=sa; Password=1";
            return conn;
        }

    }
}
