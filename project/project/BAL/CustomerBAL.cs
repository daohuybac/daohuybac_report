using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class CustomerBAL
    {
        CustomerDAL dal = new CustomerDAL();
        public List<CustomerBEL> ReadCustomer()
        {
            List<CustomerBEL> lstCus = dal.ReadCustomer();
            return lstCus;
        }
        public void NewCustomer(CustomerBEL cus)
        {
            dal.NewCustomer(cus);
        }
        public void DeleteCustomer(CustomerBEL cus)
        {
            dal.DeleteCustomer(cus);
        }
        public void EditCustomer(CustomerBEL cus)
        {
            dal.EditCustomer(cus);
        }
        public List<CustomerBEL> SearchCustomers(string searchText)
        {
            List<CustomerBEL> customers = dal.ReadCustomer(); 
            return customers.Where(c => c.Name.Contains(searchText)).ToList(); 
        }
        public List<CustomerBEL> SearchCustomersByCodestu(string codestu)
        {
            List<CustomerBEL> customers = dal.ReadCustomer();
            return customers.Where(c => c.Codestu.Contains(codestu)).ToList();
        }

        public List<CustomerBEL> SearchCustomers(string searchText, string codestu)
        {
            List<CustomerBEL> customers = dal.ReadCustomer();
            return customers
                .Where(c => c.Name.Contains(searchText) || c.Codestu.Contains(codestu))
                .ToList();
        }

    }

}
