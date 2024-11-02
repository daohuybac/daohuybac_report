using project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.BAL
{
    public class LoginBAL
    {
        private LoginDAL loginDAL;

        public LoginBAL()
        {
            loginDAL = new LoginDAL();
        }

        public bool Authenticate(string username, string password)
        {
            return loginDAL.CheckLogin(username, password);
        }
        public bool Register(string username, string password)
        {
            return loginDAL.Register(username, password);
        }
    }
}
