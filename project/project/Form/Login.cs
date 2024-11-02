using project.BAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Login : Form
    {
        private LoginBAL loginBAL;
        public Login()
        {
            InitializeComponent();
            loginBAL = new LoginBAL();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            bool isAuthenticated = loginBAL.Authenticate(username, password);

            if (isAuthenticated)
            {
                MessageBox.Show("Login successful!");
                CustomerGUI Cust = new CustomerGUI();
                Cust.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login failed! Please check your username or password.");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            this.Hide();
        }
    }
}
