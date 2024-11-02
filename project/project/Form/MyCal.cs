using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project
{
    public partial class MyCal : Form
    {
        decimal workingMemory = 0;
        string opr = "";
        decimal memory = 0; 
        public MyCal()
        {
            InitializeComponent();
            // Đăng ký sự kiện Click cho tất cả các nút
            btn0.Click += new EventHandler(Button_Click);
            btn1.Click += new EventHandler(Button_Click);
            btn2.Click += new EventHandler(Button_Click);
            btn3.Click += new EventHandler(Button_Click);
            btn4.Click += new EventHandler(Button_Click);
            btn5.Click += new EventHandler(Button_Click);
            btn6.Click += new EventHandler(Button_Click);
            btn7.Click += new EventHandler(Button_Click);
            btn8.Click += new EventHandler(Button_Click);
            btn9.Click += new EventHandler(Button_Click);
            btnDot.Click += new EventHandler(Button_Click);

            btnPlus.Click += new EventHandler(Button_Click);
            btnMinus.Click += new EventHandler(Button_Click);
            btnMulti.Click += new EventHandler(Button_Click);
            btnDivide.Click += new EventHandler(Button_Click);
            btnEquals.Click += new EventHandler(Button_Click);
            btnPercent.Click += new EventHandler(Button_Click);
            btnSqrt.Click += new EventHandler(Button_Click); // căn bậc 2 
            btnInvert.Click += new EventHandler(Button_Click); //1/x
            btnClear.Click += new EventHandler(Button_Click); //nút C
            btnCE.Click += new EventHandler(Button_Click); 
            btnMC.Click += new EventHandler(Button_Click);
            btnMR.Click += new EventHandler(Button_Click); 
            btnMS.Click += new EventHandler(Button_Click);
            btnMplus.Click += new EventHandler(Button_Click);
            btnMminus.Click += new EventHandler(Button_Click);
            btnBackspace.Click += new EventHandler(Button_Click);


            //btnMemoryClear.Click += new EventHandler(Button_Click);
            //btnMemoryRecall.Click += new EventHandler(Button_Click);
            //btnMemoryStore.Click += new EventHandler(Button_Click);
            //btnMemoryPlus.Click += new EventHandler(Button_Click);
            //btnMemoryMinus.Click += new EventHandler(Button_Click);
        }


        private void Button_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;


            if ((char.IsDigit(bt.Text, 0) && bt.Text.Length == 1) || bt.Text == ".")
            {
                tbDisplay.Text += bt.Text;
            }

            else if (bt.Text == "+" || bt.Text == "-" || bt.Text == "*" || bt.Text == "/")
            {
                opr = bt.Text;
                workingMemory = decimal.Parse(tbDisplay.Text);
                tbDisplay.Clear();
            }

            else if (bt.Text == "=")
            {
                decimal secondValue = decimal.Parse(tbDisplay.Text);
                if (opr == "+")
                {
                    tbDisplay.Text = (workingMemory + secondValue).ToString();
                }
                else if (opr == "-")
                {
                    tbDisplay.Text = (workingMemory - secondValue).ToString();
                }
                else if (opr == "*")
                {
                    tbDisplay.Text = (workingMemory * secondValue).ToString();
                }
                else if (opr == "/")
                {
                    if (secondValue != 0)
                    {
                        tbDisplay.Text = (workingMemory / secondValue).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không thể chia cho 0.");
                    }
                }
            }

            else if (bt.Text == "±")
            {
                decimal currVal = decimal.Parse(tbDisplay.Text);
                currVal = -currVal;
                tbDisplay.Text = currVal.ToString();
            }

            else if (bt.Text == "√")
            {
                decimal currVal = decimal.Parse(tbDisplay.Text);
                currVal = (decimal)Math.Sqrt((double)currVal);
                tbDisplay.Text = currVal.ToString();
            }

            else if (bt.Text == "%")
            {
                decimal currVal = decimal.Parse(tbDisplay.Text);
                currVal = currVal / 100;
                tbDisplay.Text = currVal.ToString();
            }

            else if (bt.Text == "1/x")
            {
                decimal currVal = decimal.Parse(tbDisplay.Text);
                if (currVal != 0)
                {
                    currVal = 1 / currVal;
                    tbDisplay.Text = currVal.ToString();
                }
                else
                {
                    MessageBox.Show("Không thể chia cho 0.");
                }
            }

            else if (bt.Text == "←")
            {
                if (tbDisplay.TextLength != 0)
                {
                    tbDisplay.Text = tbDisplay.Text.Remove(tbDisplay.TextLength - 1);
                }
            }

            else if (bt.Text == "MC")
            {
                memory = 0;
            }
            else if (bt.Text == "MR")
            {
                tbDisplay.Text = memory.ToString();
            }
            else if (bt.Text == "MS")
            {
                memory = decimal.Parse(tbDisplay.Text);
                tbDisplay.Clear();
            }
            else if (bt.Text == "M+")
            {
                memory += decimal.Parse(tbDisplay.Text);
            }
            else if (bt.Text == "M-")
            {
                memory -= decimal.Parse(tbDisplay.Text);
            }

            else if (bt.Text == "C")
            {
                workingMemory = 0;
                opr = "";
                tbDisplay.Clear();
            }

            else if (bt.Text == "CE")
            {
                tbDisplay.Clear();
            }
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
    }
}
