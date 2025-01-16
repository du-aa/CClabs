using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labmid_CCtask2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Compile_Click(object sender, EventArgs e)
        {
            String Initial_State = "Goal";
            String Final_State = "turn";
            var dict = new Dictionary<string, string>()
            {
                { "Goal", "CMD Goal | CMD" },
                { "CMD", "start | stop | Action" },
                { "Action", "accelerate | brake | turn" },
                { "turn", "right" }  
            };
            Output.Clear();  
            List<string> terminals = new List<string>(Input.Text.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries));

            Output.AppendText("Initial CFG:\r\n");
            PrintCFG(dict);

            if (!dict["turn"].Contains("left") && terminals.Contains("left"))
            {
                Output.AppendText("\r\nInvalid command detected: 'Left' is not in the current CFG for turn.\r\n");
                Output.AppendText("Generating updated CFG to resolve the issue...\r\n\r\n");

                // Update the CFG to include 'left'
                dict["turn"] = "left | right";
            }

            Output.AppendText("Corrected CFG:\r\n");
            PrintCFG(dict);
        }

        private void PrintCFG(Dictionary<string, string> cfg)
        {
            foreach (var rule in cfg)
            {
                Output.AppendText($"{rule.Key} → {rule.Value}\r\n");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }
    }
}
