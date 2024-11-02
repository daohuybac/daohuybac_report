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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

       

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text; 
            string password = txtPassword.Text;

            if (!IsValidPassword(password))
            {
                MessageBox.Show("Password must be at least 6 characters long and contain at least one uppercase letter, one lowercase letter, and one digit.");
                return; 
            }

            LoginBAL loginBAL = new LoginBAL();
            bool isRegistered = loginBAL.Register(username, password);

            if (isRegistered)
            {
                MessageBox.Show("Register successful!");
                Login Log = new Login();
                Log.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username already exists. Please choose a different username.");
            }
        }
        private bool IsValidPassword(string password)
        {
            // Kiểm tra độ dài
            if (password.Length <= 5)
            {
                return false; // Mật khẩu phải có hơn 5 ký tự
            }

            bool hasUpperCase = password.Any(char.IsUpper); // Kiểm tra có chữ hoa
            bool hasLowerCase = password.Any(char.IsLower); // Kiểm tra có chữ thường
            bool hasDigit = password.Any(char.IsDigit);     // Kiểm tra có chữ số
            char[] specialCharacters = { '.', ',', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '=', '+', '~', '`' }; // Các ký tự đặc biệt
            bool hasSpecialChar = password.Any(c => specialCharacters.Contains(c));
            return hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar;
        }
    }
}
