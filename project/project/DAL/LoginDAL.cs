using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.DAL
{
    public class LoginDAL
    {
        private DBConnection dbConnection;

        public LoginDAL()
        {
            dbConnection = new DBConnection();
        }

        public bool CheckLogin(string username, string password)
        {
            using (SqlConnection conn = dbConnection.CreateConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(1) FROM [user] WHERE username = @username AND password = @password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    return result > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while checking login", ex);
                }
            }
        }
        public bool Register(string username, string password)
        {
            using (SqlConnection conn = dbConnection.CreateConnection())
            {
                try
                {
                    conn.Open();
                    
                    string checkQuery = "SELECT COUNT(1) FROM [user] WHERE username = @username";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@username", username);
                    int userExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (userExists > 0)
                    {
                        return false; 
                    }

                    
                    string insertQuery = "INSERT INTO [user] (username, password) VALUES (@username, @password)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@username", username);
                    insertCmd.Parameters.AddWithValue("@password", password); 

                    int result = insertCmd.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while registering user", ex);
                }
            }
        }

    }
}
