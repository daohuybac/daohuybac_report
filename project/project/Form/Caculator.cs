using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Caculator : Form
    {
        public Caculator()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("caculator.txt", true);
            sw.Write(textBox6.Text);
            sw.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox4.Text);
            int y = int.Parse(textBox5.Text);
            int kq = x + y;
            textBox6.Text = textBox6.Text + x.ToString() + " + " + y.ToString() + " = " + kq.ToString() + "\r\n";
        }

        private void btnmulti_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox4.Text);
            int y = int.Parse(textBox5.Text);
            int kq = x * y;
            textBox6.Text = textBox6.Text + x.ToString() + " * " + y.ToString() + " = " + kq.ToString() + "\r\n";
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Form1 fr01 = new Form1();
            fr01.Show();
            this.Hide();
        }
    }
}
