using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GrammarValidator
{
    public partial class Form1 : Form
    {
        // Patterns for grammar constructs
        private const string StartSymbol = @"^(x|y)\s+(y|z)\s*;$"; // S -> A B ;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            // Read input code from textbox
            string code = txtCodeInput.Text;

            // Validate the input code
            if (IsValidGrammar(code))
            {
                lblResult.Text = "Valid grammar construct";
                lblResult.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblResult.Text = "Invalid grammar construct";
                lblResult.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Method to check if the input matches the grammar rules
        private bool IsValidGrammar(string code)
        {
            return MatchesPattern(StartSymbol, code);
        }

        // Helper method to match code with a given regex pattern
        private bool MatchesPattern(string pattern, string code)
        {
            Regex regex = new Regex(pattern, RegexOptions.Singleline);
            return regex.IsMatch(code);
        }
    }
}

