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

namespace RegEx
{
    public partial class RelationalOperators : Form
    {
        public RelationalOperators()
        {
            InitializeComponent();
        }

        private void RelationalOperators_Load(object sender, EventArgs e)
        {
            // Get the input from the textbox
            string inputText = inputTextBox.Text;

            // Regular expression to find logical operators
            string relationalOperatorsPattern = @"==|!=|>=|<=|>|<";

            // Use Regex to find matches in the input text
            MatchCollection matches = Regex.Matches(inputText, relationalOperatorsPattern);

            // Prepare output by extracting all matched operators
            string outputText = "";
            foreach (Match match in matches)
            {
                outputText += match.Value + Environment.NewLine;

            }

            // Show the matched logical operators in the output textbox
            outputTextBox.Text = outputText;
        }
    
    }
}
