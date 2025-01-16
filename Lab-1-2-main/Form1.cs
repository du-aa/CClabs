namespace scientific_calculator
{
    public partial class Form1 : Form
    {
        double result = 0;
        string operation = "";
        bool operationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void AppendNumber(string number)
        {
            if (Display1.Text == "0" || operationPerformed)
                Display1.Clear();

            operationPerformed = false;
            Display1.Text += number;
        }

        private void one_Click(object sender, EventArgs e)
        {
            AppendNumber("1");


        }

        private void two_Click(object sender, EventArgs e)
        {
            AppendNumber("2");

        }

        private void three_Click(object sender, EventArgs e)
        {
            AppendNumber("3");

        }

        private void four_Click(object sender, EventArgs e)
        {
            AppendNumber("4");

        }

        private void five_Click(object sender, EventArgs e)
        {
            AppendNumber("5");

        }

        private void six_Click(object sender, EventArgs e)
        {
            AppendNumber("6");

        }

        private void seven_Click(object sender, EventArgs e)
        {
            AppendNumber("7");


        }

        private void eight_Click(object sender, EventArgs e)
        {
            AppendNumber("8");

        }

        private void nine_Click(object sender, EventArgs e)
        {
            AppendNumber("9");

        }

        private void zero_Click(object sender, EventArgs e)
        {
            AppendNumber("0");


        }

        private void clear_Click(object sender, EventArgs e)
        {
            Display1.Text = "0";
            result = 0;
        }


        private double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }
        private void sin_Click(object sender, EventArgs e)
        {
            Display1.Text = Math.Sin(ConvertToRadians(Double.Parse(Display1.Text))).ToString();

        }

        private void cos_Click(object sender, EventArgs e)
        {
            Display1.Text = Math.Cos(ConvertToRadians(Double.Parse(Display1.Text))).ToString();

        }

        private void Tan_Click(object sender, EventArgs e)
        {
            Display1.Text = Math.Tan(ConvertToRadians(Double.Parse(Display1.Text))).ToString();

        }

        private void Log_Click(object sender, EventArgs e)
        {
            Display1.Text = Math.Log2(Double.Parse(Display1.Text)).ToString();

        }
    }
}
