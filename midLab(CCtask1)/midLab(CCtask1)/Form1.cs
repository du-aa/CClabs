using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace midLab_CCtask1_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string password = GeneratePassword();
            txtOutput.Text = password;
        }

        private string GeneratePassword()
        {
            // Create a StringBuilder to hold the password characters
            StringBuilder password = new StringBuilder();

            // Ensure inclusion of required characters
            password.Append("1"); // Add digit 1
            password.Append("6"); // Add digit 6
            password.Append("u"); // Add letter u
            password.Append("a"); // Add letter a
            password.Append("h"); // Add letter h
            password.Append("p"); // Add letter p

            // Add random characters to reach the total length of 16
            Random rand = new Random();
            while (password.Length < 14)
            {
                char randomChar = GetRandomChar(rand);
                password.Append(randomChar);
            }

            // Shuffle the password to ensure randomness
            return ShuffleString(password.ToString());
        }

        private char GetRandomChar(Random rand)
        {
            // Choose a random character from digits, letters, and special characters
            char[] allChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()".ToCharArray();
            return allChars[rand.Next(allChars.Length)];
        }

        private string ShuffleString(string input)
        {
            char[] array = input.ToCharArray();
            Random rand = new Random();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                // Swap
                char temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            return new string(array);
        }

    }
}
