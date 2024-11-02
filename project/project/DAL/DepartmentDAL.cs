using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class DepartmentDAL : DBConnection
    {

        public List<DepartmentBEL> ReadDepartmentList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Department", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<DepartmentBEL> lstDepart = new List<DepartmentBEL>();
            while (reader.Read())
            {
                DepartmentBEL depart = new DepartmentBEL();
                depart.Id = int.Parse(reader["id"].ToString());
                depart.Name = reader["name"].ToString();
                lstDepart.Add(depart);
            }
            conn.Close();
            return lstDepart;
        }
        public DepartmentBEL ReadDepartment(int id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "select * from Department where id=" + id.ToString(), conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DepartmentBEL depart = new DepartmentBEL();
            if (reader.HasRows && reader.Read())
            {
                depart.Id = int.Parse(reader["id"].ToString());
                depart.Name = reader["name"].ToString();
            }
            conn.Close();
            return depart;
        }
        public int? GetDepartmentIdByName(string name)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT id FROM Department WHERE name=@Name", conn);
            cmd.Parameters.AddWithValue("@Name", name);
            SqlDataReader reader = cmd.ExecuteReader();

            int? departmentId = null; 
            if (reader.HasRows && reader.Read())
            {
                departmentId = int.Parse(reader["id"].ToString());
            }
            conn.Close();
            return departmentId; 
        }


    }
}
