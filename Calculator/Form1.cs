namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Calculator calc = new();

        private void Form1_Load(object sender, EventArgs e)
        {
            txtDisplay.Text = calc.DisplayString;
        }

        // This method handles the 0 through 9 keys 
        private void btnNumber_Click(object sender, EventArgs e)
        {
            calc.Append(((Button)sender).Text);
            txtDisplay.Text = calc.DisplayString;
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            calc.RemoveLast();
            txtDisplay.Text = calc.DisplayString;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            calc.Clear();
            txtDisplay.Text = calc.DisplayString;
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            calc.AddDecimalPoint();
            txtDisplay.Text = calc.DisplayString;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            calc.ToggleSign();
            txtDisplay.Text = calc.DisplayString;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            calc.Add();
            txtDisplay.Text = calc.DisplayString;
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            calc.Subtract();
            txtDisplay.Text = calc.DisplayString;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            calc.Multiply();
            txtDisplay.Text = calc.DisplayString;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            calc.Divide();
            txtDisplay.Text = calc.DisplayString;
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            calc.SquareRoot();
            txtDisplay.Text = calc.DisplayString;
        }

        private void btnReciprocal_Click(object sender, EventArgs e)
        {
            try
            {
                calc.Reciprocal();
                txtDisplay.Text = calc.DisplayString;
            }
            catch (DivideByZeroException)
            {
                calc.Clear();
                txtDisplay.Text = "Cannot divide by zero.";
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            try
            {
                calc.Equals();
                txtDisplay.Text = calc.DisplayString;
            }
            catch (DivideByZeroException)
            {
                calc.Clear();
                txtDisplay.Text = "Cannot divide by zero.";
            }
        }
    }
}