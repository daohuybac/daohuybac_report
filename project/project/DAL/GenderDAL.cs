using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
   
    public class GenderDAL : DBConnection
    {

        public List<GenderBEL> ReadGenderList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Gender", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<GenderBEL> lstGender = new List<GenderBEL>();
            while (reader.Read())
            {
                GenderBEL gender = new GenderBEL();
                gender.Id = int.Parse(reader["id"].ToString());
                gender.Name = reader["name"].ToString();
                lstGender.Add(gender);
            }
            conn.Close();
            return lstGender;
        }
        public GenderBEL ReadGender(int id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Gender where id = @id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader reader = cmd.ExecuteReader();
            GenderBEL gender = new GenderBEL();
            if (reader.HasRows && reader.Read())
            {
                gender.Id = int.Parse(reader["id"].ToString());
                gender.Name = reader["name"].ToString();
            }
            conn.Close();
            return gender;
        }
        public int? GetGenderIdByName(string name)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT id FROM Gender WHERE name = @Name", conn);
            cmd.Parameters.AddWithValue("@Name", name);
            SqlDataReader reader = cmd.ExecuteReader();

            int? genderId = null; 
            if (reader.HasRows && reader.Read())
            {
                genderId = int.Parse(reader["id"].ToString());
            }
            conn.Close();
            return genderId; 
        }


    }
}
