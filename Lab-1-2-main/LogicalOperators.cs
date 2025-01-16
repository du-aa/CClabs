using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LogicalOperatorsRegex
{
    public partial class LogicalOperators : Form
    {
        public LogicalOperators()
        {
            InitializeComponent();
        }

        private void processButton_Click(object sender, EventArgs e)
        {
            // Get the input from the textbox
            string inputText = inputTextBox.Text;

            // Regular expression to find logical operators
            string logicalOperatorsPattern = @"\b(AND|OR|NOT|\|\||&&|!)\b";

            // Use Regex to find matches in the input text
            MatchCollection matches = Regex.Matches(inputText, logicalOperatorsPattern);

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
