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
    public partial class Form2 : Form
    {
        Form1 form1;
        public Form2(Form1 f1)
        {
            form1 = f1;
            InitializeComponent();
        }
         
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void BtnNormalcalc_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }

        private void BtnNorCalc_Click(object sender, EventArgs e)
        {
            form1.Show();
            Hide();
            // Switch back to form 1
        }

        private void BtnHexDec_Click(object sender, EventArgs e)
        {
            string hex_value = textBox2.Text; // input a string into text box
            int int_value = Convert.ToInt32(hex_value, 16); // Converts the hex value to denary value 
            textBox3.Text = int_value.ToString(); // inputs denary value variable is int_value


            
        }

        private void BtnDecBin_Click(object sender, EventArgs e)
        {
            int int_value = int.Parse(textBox2.Text); // inputs an integer value into textbox and parse because only string can be inputted so it is a cast
            string bin_value = Convert.ToString(int_value, 2);
            textBox3.Text = bin_value.ToString();
        }

        private void BtnDecHex_Click(object sender, EventArgs e)
        {
            int int_value = int.Parse(textBox2.Text); // inputs an integer value into textbox and parse because only string can be inputted so it is a cast
            if (int_value < 1) // No hex value for anything less than 1
            {
                textBox3.Text = "0";
            }

            int hex_value = int_value;
            string hexStr = string.Empty;

            while (int_value > 0)
            {
                hex_value = int_value % 16; 

                if (hex_value < 10)
                    hexStr = hexStr.Insert(0, Convert.ToChar(hex_value + 48).ToString()); // After 10 in hex it is A B C D E F till it is 16 
                else
                    hexStr = hexStr.Insert(0, Convert.ToChar(hex_value + 55).ToString()); // If hex value is over 10 it has to be assigned a letter

                int_value /= 16;
                textBox3.Text = hexStr.ToString();
            }

            
        }

        private void BtnBinDec_Click(object sender, EventArgs e)
        {
            string bin_value = textBox2.Text; // input a string into text box
            int int_value = Convert.ToInt32(bin_value, 2);
            textBox3.Text = int_value.ToString();
        }

        private void BtnHexBin_Click(object sender, EventArgs e)
        {
            string hex_value = textBox2.Text; // input a string into text box
            string bin_value = Convert.ToString(Convert.ToInt32(hex_value, 16),2);
            textBox3.Text = bin_value.ToString();

        }

        private void BtnBinHex_Click(object sender, EventArgs e)
        {
            string bin_value = textBox2.Text; // input a string into text box
            int int_value = Convert.ToInt32(bin_value, 2);
            


            if (int_value < 1)
            {
                textBox3.Text = "0";
            }

            int hex_value = int_value;
            string hexStr = string.Empty;

            while (int_value > 0)
            {
                hex_value = int_value % 16;

                if (hex_value < 10)
                    hexStr = hexStr.Insert(0, Convert.ToChar(hex_value + 48).ToString()); // After 10 in hex it is A B C D E F till it is 16 
                else
                    hexStr = hexStr.Insert(0, Convert.ToChar(hex_value + 55).ToString());  // If hex value is over 10 it has to be assigned a letter

                int_value /= 16;
                textBox3.Text = hexStr.ToString();
                // The code for this button first converts Bin to Denary then converts Denary to hex
            }

        }
        
    }
}
