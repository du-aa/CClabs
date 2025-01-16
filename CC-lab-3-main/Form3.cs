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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            dataGridViewResults.ColumnCount = 1;
            dataGridViewResults.Columns[0].Name = "Words Starting with 't' or 'm'";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = richTextBox1.Text;

            // Regular expression for words starting with 't' or 'm'
            string pattern = @"\b[tTmM]\w*\b";

            // Find all matches
            MatchCollection matches = Regex.Matches(input, pattern);

            // Clear previous results in DataGridView
            dataGridViewResults.Rows.Clear();

            // Loop through all the matches and add them to the DataGridView
            foreach (Match match in matches)
            {
                dataGridViewResults.Rows.Add(match.Value);
            }

            // Show message if no matches are found
            if (matches.Count == 0)
            {
                MessageBox.Show("No words starting with 't' or 'm' found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            richTextBox1.Clear();

        
    }
    }
}
