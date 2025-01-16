using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scientific_calculator
{
    public partial class gridview : Form
    {
        public gridview()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //age
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //name
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //country
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ensure all fields are filled
            if (!string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                // Validate the Age input (you can add more validation if necessary)
                if (int.TryParse(textBox1.Text, out int age))
                {
                    // Add the data to the DataGridView
                    dataGridView1.Rows.Add(textBox3.Text, age, textBox2.Text);

                    // Clear TextBox fields after inserting
                    textBox3.Clear();
                    textBox1.Clear();
                    textBox2.Clear();
                }
                else
                {
                    // Handle invalid age input (not a number)
                    MessageBox.Show("Please enter a valid number for Age.");
                }
            }
            else
            {
                // Handle case where any field is empty
                MessageBox.Show("Please fill all fields.");
            }

        }

        private void gridview_Load(object sender, EventArgs e)
        {
            // Adding columns if they don't exist
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("Name", "Name");
                dataGridView1.Columns.Add("Age", "Age");
                dataGridView1.Columns.Add("Country", "Country");
            }
        }
    }
}
