using project;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class CustomerDAL : DBConnection
    {
        public List<CustomerBEL> ReadCustomer()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Customer", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<CustomerBEL> lstCus = new List<CustomerBEL>();
            DepartmentDAL depL = new DepartmentDAL();
            AreaDAL areL = new AreaDAL();
            GenderDAL genL = new GenderDAL();
            while (reader.Read())
            {
                CustomerBEL cus = new CustomerBEL();
                cus.Id = int.Parse(reader["id"].ToString());
                cus.Codestu = reader["code_stu"].ToString();
                cus.Name = reader["name"].ToString();
                cus.DateOfBirth = DateTime.Parse(reader["date_of_birth"].ToString());
                cus.Gender = genL.ReadGender(int.Parse(reader["id_gender"].ToString()));
                cus.Class = reader["class"].ToString();
                cus.Department = depL.ReadDepartment(int.Parse(reader["id_department"].ToString()));
                cus.Area = areL.ReadArea(int.Parse(reader["id_area"].ToString()));
                cus.Score = decimal.Parse(reader["score"].ToString());
                cus.Phone = reader["phone"].ToString();
                cus.Email = reader["email"].ToString();
                cus.Address = reader["address"].ToString();
                cus.ImageUrl = reader["imageUrl"] != DBNull.Value ? reader["imageUrl"].ToString() : null;


                lstCus.Add(cus);
            }
            conn.Close();
            return lstCus;
        }
        public void DeleteCustomer(CustomerBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Customer where id =@id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.Id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void NewCustomer(CustomerBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Customer values(@id,@code_stu,@name,@date_of_birth," +
                "@id_gender,@class,@id_department,@id_area,@score,@phone,@email,@address,@imageUrl)", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.Id));
            cmd.Parameters.Add(new SqlParameter("@code_stu", cus.Codestu));
            cmd.Parameters.Add(new SqlParameter("@name", cus.Name));
            cmd.Parameters.Add(new SqlParameter("@date_of_birth", cus.DateOfBirth));
            cmd.Parameters.Add(new SqlParameter("@id_gender", cus.Gender.Id));
            cmd.Parameters.Add(new SqlParameter("@class", cus.Class));
            cmd.Parameters.Add(new SqlParameter("@id_department", cus.Department.Id));
            cmd.Parameters.Add(new SqlParameter("@id_area", cus.Area.Id));
            cmd.Parameters.Add(new SqlParameter("@score", cus.Score));
            cmd.Parameters.Add(new SqlParameter("@phone", cus.Phone));
            cmd.Parameters.Add(new SqlParameter("@email", cus.Email));
            cmd.Parameters.Add(new SqlParameter("@address", cus.Address));
            cmd.Parameters.Add(new SqlParameter("@imageUrl", cus.ImageUrl));

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void EditCustomer(CustomerBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Customer SET  code_stu = @code_stu, name = @name, date_of_birth = @date_of_birth," +
                " id_gender = @id_gender, class = @class, id_department = @id_department, id_area = @id_area, " +
                "score = @score, phone = @phone, email = @email, address = @address, imageUrl = @imageUrl WHERE id = @id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.Id));
            cmd.Parameters.Add(new SqlParameter("@code_stu", cus.Codestu));
            cmd.Parameters.Add(new SqlParameter("@name", cus.Name));
            cmd.Parameters.Add(new SqlParameter("@date_of_birth", cus.DateOfBirth));
            cmd.Parameters.Add(new SqlParameter("@id_gender", cus.Gender.Id));
            cmd.Parameters.Add(new SqlParameter("@class", cus.Class));
            cmd.Parameters.Add(new SqlParameter("@id_department", cus.Department.Id));
            cmd.Parameters.Add(new SqlParameter("@id_area", cus.Area.Id));
            cmd.Parameters.Add(new SqlParameter("@score", cus.Score));
            cmd.Parameters.Add(new SqlParameter("@phone", cus.Phone));
            cmd.Parameters.Add(new SqlParameter("@email", cus.Email));
            cmd.Parameters.Add(new SqlParameter("@address", cus.Address));
            cmd.Parameters.Add(new SqlParameter("@imageUrl", cus.ImageUrl));
            



            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }

}
