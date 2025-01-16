namespace scientific_calculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Display1 = new TextBox();
            zero = new Button();
            cos = new Button();
            nine = new Button();
            Log = new Button();
            Tan = new Button();
            eight = new Button();
            two = new Button();
            seven = new Button();
            six = new Button();
            five = new Button();
            one = new Button();
            four = new Button();
            three = new Button();
            clear = new Button();
            sin = new Button();
            SuspendLayout();
            // 
            // Display1
            // 
            Display1.Location = new Point(36, 27);
            Display1.Name = "Display1";
            Display1.Size = new Size(227, 23);
            Display1.TabIndex = 0;
            // 
            // zero
            // 
            zero.Location = new Point(107, 101);
            zero.Name = "zero";
            zero.Size = new Size(75, 23);
            zero.TabIndex = 1;
            zero.Text = "0";
            zero.UseVisualStyleBackColor = true;
            zero.Click += zero_Click;
            // 
            // cos
            // 
            cos.Location = new Point(188, 72);
            cos.Name = "cos";
            cos.Size = new Size(75, 23);
            cos.TabIndex = 2;
            cos.Text = "cos";
            cos.UseVisualStyleBackColor = true;
            cos.Click += cos_Click;
            // 
            // nine
            // 
            nine.Location = new Point(188, 130);
            nine.Name = "nine";
            nine.Size = new Size(75, 23);
            nine.TabIndex = 3;
            nine.Text = "9";
            nine.UseVisualStyleBackColor = true;
            nine.Click += nine_Click;
            // 
            // Log
            // 
            Log.Location = new Point(188, 101);
            Log.Name = "Log";
            Log.Size = new Size(75, 23);
            Log.TabIndex = 4;
            Log.Text = "Log";
            Log.UseVisualStyleBackColor = true;
            Log.Click += Log_Click;
            // 
            // Tan
            // 
            Tan.Location = new Point(26, 101);
            Tan.Name = "Tan";
            Tan.Size = new Size(75, 23);
            Tan.TabIndex = 5;
            Tan.Text = "Tan";
            Tan.UseVisualStyleBackColor = true;
            Tan.Click += Tan_Click;
            // 
            // eight
            // 
            eight.Location = new Point(107, 130);
            eight.Name = "eight";
            eight.Size = new Size(75, 23);
            eight.TabIndex = 6;
            eight.Text = "8";
            eight.UseVisualStyleBackColor = true;
            eight.Click += eight_Click;
            // 
            // two
            // 
            two.Location = new Point(107, 188);
            two.Name = "two";
            two.Size = new Size(75, 23);
            two.TabIndex = 7;
            two.Text = "2";
            two.UseVisualStyleBackColor = true;
            two.Click += two_Click;
            // 
            // seven
            // 
            seven.Location = new Point(26, 130);
            seven.Name = "seven";
            seven.Size = new Size(75, 23);
            seven.TabIndex = 8;
            seven.Text = "7";
            seven.UseVisualStyleBackColor = true;
            seven.Click += seven_Click;
            // 
            // six
            // 
            six.Location = new Point(188, 159);
            six.Name = "six";
            six.Size = new Size(75, 23);
            six.TabIndex = 9;
            six.Text = "6";
            six.UseVisualStyleBackColor = true;
            six.Click += six_Click;
            // 
            // five
            // 
            five.Location = new Point(107, 159);
            five.Name = "five";
            five.Size = new Size(75, 23);
            five.TabIndex = 10;
            five.Text = "5";
            five.UseVisualStyleBackColor = true;
            five.Click += five_Click;
            // 
            // one
            // 
            one.Location = new Point(26, 188);
            one.Name = "one";
            one.Size = new Size(75, 23);
            one.TabIndex = 11;
            one.Text = "1";
            one.UseVisualStyleBackColor = true;
            one.Click += one_Click;
            // 
            // four
            // 
            four.Location = new Point(26, 159);
            four.Name = "four";
            four.Size = new Size(75, 23);
            four.TabIndex = 12;
            four.Text = "4";
            four.UseVisualStyleBackColor = true;
            four.Click += four_Click;
            // 
            // three
            // 
            three.Location = new Point(188, 188);
            three.Name = "three";
            three.Size = new Size(75, 23);
            three.TabIndex = 13;
            three.Text = "3";
            three.UseVisualStyleBackColor = true;
            three.Click += three_Click;
            // 
            // clear
            // 
            clear.Location = new Point(107, 72);
            clear.Name = "clear";
            clear.Size = new Size(75, 23);
            clear.TabIndex = 14;
            clear.Text = "clear";
            clear.UseVisualStyleBackColor = true;
            clear.Click += clear_Click;
            // 
            // sin
            // 
            sin.Location = new Point(26, 72);
            sin.Name = "sin";
            sin.Size = new Size(75, 23);
            sin.TabIndex = 15;
            sin.Text = "sin";
            sin.UseVisualStyleBackColor = true;
            sin.Click += sin_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(295, 243);
            Controls.Add(sin);
            Controls.Add(clear);
            Controls.Add(three);
            Controls.Add(four);
            Controls.Add(one);
            Controls.Add(five);
            Controls.Add(six);
            Controls.Add(seven);
            Controls.Add(two);
            Controls.Add(eight);
            Controls.Add(Tan);
            Controls.Add(Log);
            Controls.Add(nine);
            Controls.Add(cos);
            Controls.Add(zero);
            Controls.Add(Display1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Display1;
        private Button zero;
        private Button cos;
        private Button nine;
        private Button Log;
        private Button Tan;
        private Button eight;
        private Button two;
        private Button seven;
        private Button six;
        private Button five;
        private Button one;
        private Button four;
        private Button three;
        private Button clear;
        private Button sin;
    }
}
