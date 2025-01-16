using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = richTextBox1.Text.Trim();

            // Define the regular expression for floating point numbers with max length 6
            string pattern = @"^[-+]?\d{1,6}(\.\d{0,5})?$";

            // Validate the input using the regular expression
            if (Regex.IsMatch(input, pattern))
            {
                // If valid, show success message
                label1.Text = "Valid floating-point number!";
                label1.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                // If not valid, show error message
                label1.Text = "Invalid input!";
                label1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
