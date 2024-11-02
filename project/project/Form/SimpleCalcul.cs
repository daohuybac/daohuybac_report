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
    public partial class SimpleCalcul : Form
    {
        decimal workingMemory = 0;
        string opr = "";
        public SimpleCalcul()
        {
            InitializeComponent();
        }

        private void tbDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Form1 fr01 = new Form1();
            fr01.Show();
            this.Hide();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            tbDisplay.Clear();
        }

        private void btnmul_Click(object sender, EventArgs e)
        {
            opr = btnmul.Text;
            workingMemory = decimal.Parse(tbDisplay.Text);
            tbDisplay.Clear();
        }

        private void btnplus_Click(object sender, EventArgs e)
        {
            opr = btnplus.Text;
            workingMemory = decimal.Parse(tbDisplay.Text);
            tbDisplay.Clear();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            tbDisplay.Text += btn3.Text;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            tbDisplay.Text += btn2.Text;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            tbDisplay.Text += btn0.Text;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            tbDisplay.Text += btn1.Text;
        }

        private void btnequals_Click(object sender, EventArgs e)
        {
            decimal secondValue;
            if (decimal.TryParse(tbDisplay.Text, out secondValue))
            {
                if (opr == "+")
                    tbDisplay.Text = (workingMemory + secondValue).ToString();
                else if (opr == "*")
                    tbDisplay.Text = (workingMemory * secondValue).ToString();
                else
                    tbDisplay.Text = "Error";
            }
            else
            {
                tbDisplay.Text = "Error";
            }
        }

        private void btndot_Click(object sender, EventArgs e)
        {
            tbDisplay.Text += btndot.Text;
        }
    }
}
