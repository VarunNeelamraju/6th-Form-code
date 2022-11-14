using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc_Real
{
    public partial class Form1 : Form
    {
        Form2 form2; //intialize form 2 for the dec to bin to hex conversions
        public Form1()
         
        {
            InitializeComponent();
        }
        double num1, ans; // initializing the variables
        int count;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void Btn1_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "1"; 
        }

        private void Btn2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void Btn3_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void Btn4_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void Btn5_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void Btn6_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void Btn7_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void Btn8_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void Btn9_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void Btn0_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void Btn00_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void Btnplus_Click_1(object sender, EventArgs e)
        {
            num1 = double.Parse(textBox1.Text); // Converts the number from string to double float point
            textBox1.Clear();
            textBox1.Focus();
            count = 2;
        }

        private void Btnminus_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                num1 = double.Parse(textBox1.Text); // Converts the number from string to double float point
                textBox1.Clear();
                textBox1.Focus();
                count = 1;
            }
        }

        private void Btndivide_Click_1(object sender, EventArgs e)
        {
            num1 = double.Parse(textBox1.Text); // Converts the number from string to double float point
            textBox1.Clear();
            textBox1.Focus();
            count = 4;
        }

        private void Btnmultiply_Click_1(object sender, EventArgs e)
        {
            num1 = double.Parse(textBox1.Text); // Converts the number from string to double float point
            textBox1.Clear();
            textBox1.Focus();
            count = 3;
        }

        private void Btndot_Click_1(object sender, EventArgs e)
        {
            int c = textBox1.TextLength;
            int flag = 0;
            string text = textBox1.Text;
            for (int i = 0; i < c; i++)
            {
                if (text[i].ToString() == ".")
                {
                    flag = 1; break;
                }
                else
                {
                    flag = 0;
                }
            }
            if (flag == 0)
            {
                textBox1.Text = textBox1.Text + ".";
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void BtnSin_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(textBox1.Text); // Converts the number from string to double float point
            num1 = Math.Sin(num1); // returns the sin of the number
            textBox1.Text = num1.ToString();
        }

        private void BtnCos_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(textBox1.Text); // Converts the number from string to double float point
            num1 = Math.Cos(num1); // returns the cosine of the number
            textBox1.Text = num1.ToString();
        }

        private void BtnTan_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(textBox1.Text); // Converts the number from string to double float point
            num1 = Math.Tan(num1); // returns the tan of the number
            textBox1.Text = num1.ToString();
        }

        private void BtnPi_Click(object sender, EventArgs e)
        {
            num1 = Math.PI; // Initializes the number a Pi
            textBox1.Text = num1.ToString();
        }

        private void BtnExponential_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(textBox1.Text); // Converts the number from string to double float point
            num1 = Math.Exp(num1); // Does e to the power of num1
            textBox1.Text = num1.ToString(); // Converts the num1 to a string
        }

        private void BtnOff_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnSqr_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(textBox1.Text); // Converts the number from string to double float point
            num1 = Math.Pow(num1,2); 
            textBox1.Text = num1.ToString(); 
        }

        private void BtnCbrt_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(textBox1.Text);
            num1 = Math.Exp(num1);
            textBox1.Text = num1.ToString();
        }

        private void BtnLog_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(textBox1.Text); // Converts the number from string to double float point
            num1 = Math.Log10(num1);
            textBox1.Text = num1.ToString();
        }

        private void BtnMod_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(textBox1.Text); // Converts the number from string to double float point
            num1 = (num1 % double.Parse(textBox1.Text));
            textBox1.Text = num1.ToString();
        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; // Gives a blank in the textbox
        }

        private void BtnSqrt_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(textBox1.Text); // Converts the number from string to double float point
            num1 = Math.Sqrt(num1); // Gives the square root of a number
            textBox1.Text = num1.ToString(); 
        }

        private void BtnQdeq_Click(object sender, EventArgs e)
        {
            if (form2 == null)
            {
                form2 = new Form2(this);
            }
            form2.Show();
            Hide();
            // This is used to switch between the forms
        }

        private void Btnequal_Click_1(object sender, EventArgs e)
        { 
            {
                compute(count);
            }
             void compute(int count)
            {
                switch (count)
                {
                    case 1:
                        ans = num1 - double.Parse(textBox1.Text);  // Use of switch case instead of if else to carry out basic arithemtic operations * / + -
                        textBox1.Text = ans.ToString();
                        break;
                    case 2:
                        ans = num1 + double.Parse(textBox1.Text);
                        textBox1.Text = ans.ToString();
                        break;
                    case 3:
                        ans = num1 * double.Parse(textBox1.Text);
                        textBox1.Text = ans.ToString();
                        break;
                    case 4:
                        ans = num1 / double.Parse(textBox1.Text);
                        textBox1.Text = ans.ToString();
                        break;
                    default:
                        break;

                }
            }
        }
    }
}       



        
    

