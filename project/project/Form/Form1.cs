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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Caculator cacul = new Caculator();
            cacul.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SimpleCalcul calcu = new SimpleCalcul();
            calcu.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyCal myCal = new MyCal();
            myCal.Show();
            this.Hide();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            ADOExample ADO = new ADOExample();
            ADO.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login Log = new Login();
            Log.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ImageForm img = new ImageForm();
            img.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to Exit ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
