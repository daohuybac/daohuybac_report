using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class CustomerBEL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderBEL Gender { get; set; }
        public string GenderName
        {
            get { return Gender.Name; }
        }
        public string Class { get; set; }
        public DepartmentBEL Department { get; set; }
        public string DepartmentName
        {
            get { return Department.Name; }
        }


        public AreaBEL Area { get; set; }
        public string AreaName
        {
            get {return Area.Name;}
        }
        public decimal Score { get; set; }
        public string Phone { get; set; }
        public string Codestu { get; set; }
        
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }







    }
    public class DepartmentBEL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CustomerBEL> Customers { get; set; }
    }
    public class AreaBEL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List <CustomerBEL> Customers { get; set; }
    }
    public class GenderBEL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CustomerBEL> Customers { get; set; }
    }
}