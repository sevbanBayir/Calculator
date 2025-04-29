using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private double firstNumber = 0;
        private bool isNewNumber = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (isNewNumber)
            {
                txtDisplay.Text = button.Text;
                isNewNumber = false;
            }
            else
            {
                txtDisplay.Text += button.Text;
            }
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                firstNumber = double.Parse(txtDisplay.Text);
                isNewNumber = true;
            }
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text) && !isNewNumber)
            {
                double secondNumber = double.Parse(txtDisplay.Text);
                double result = firstNumber + secondNumber;
                txtDisplay.Text = result.ToString();
                isNewNumber = true;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            firstNumber = 0;
            isNewNumber = true;
        }

        private TextBox txtDisplay;
        private Button btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn0;
        private Button btnPlus, btnEquals, btnClear;
    }
} 