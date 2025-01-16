using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form2 : Form

    {
        private string scientificNotationRegex = @"^[+-]?[0-9]+([eE][+-]?[0-9]+)?$";

        public Form2()
        {
            InitializeComponent();
            dataGridViewResults.ColumnCount = 1;
            dataGridViewResults.Columns[0].Name = "Validated Number";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = richTextBox1.Text.Trim();

            // Validate the input using the regular expression
            if (Regex.IsMatch(input, scientificNotationRegex))
            {
                // If valid, add the value to the DataGridView
                dataGridViewResults.Rows.Add(input);
                label1.Text = "Value added successfully!";
            }
            else
            {
                // If not valid, show an error message
                label1.Text = "Invalid number format. Please enter a valid number.";
            }

            // Clear the RichTextBox after submission
            richTextBox1.Clear();
        }
    }
    }
