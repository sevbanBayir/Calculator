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

        private void InitializeComponent()
        {
            this.txtDisplay = new TextBox();
            this.btn1 = new Button();
            this.btn2 = new Button();
            this.btn3 = new Button();
            this.btn4 = new Button();
            this.btn5 = new Button();
            this.btn6 = new Button();
            this.btn7 = new Button();
            this.btn8 = new Button();
            this.btn9 = new Button();
            this.btn0 = new Button();
            this.btnPlus = new Button();
            this.btnEquals = new Button();
            this.btnClear = new Button();

            // TextBox
            this.txtDisplay.Location = new System.Drawing.Point(12, 12);
            this.txtDisplay.Size = new System.Drawing.Size(260, 20);
            this.txtDisplay.ReadOnly = true;
            this.txtDisplay.TextAlign = HorizontalAlignment.Right;

            // Buttons
            int buttonSize = 60;
            int spacing = 5;
            int startX = 12;
            int startY = 50;

            for (int i = 0; i < 10; i++)
            {
                Button btn = new Button();
                btn.Text = i.ToString();
                btn.Size = new System.Drawing.Size(buttonSize, buttonSize);
                btn.Click += NumberButton_Click;
                this.Controls.Add(btn);

                if (i == 0)
                {
                    btn.Location = new System.Drawing.Point(startX, startY + (buttonSize + spacing) * 3);
                }
                else
                {
                    int row = (i - 1) / 3;
                    int col = (i - 1) % 3;
                    btn.Location = new System.Drawing.Point(startX + col * (buttonSize + spacing), 
                                                          startY + row * (buttonSize + spacing));
                }
            }

            // Plus button
            this.btnPlus.Text = "+";
            this.btnPlus.Size = new System.Drawing.Size(buttonSize, buttonSize);
            this.btnPlus.Location = new System.Drawing.Point(startX + 3 * (buttonSize + spacing), startY);
            this.btnPlus.Click += OperationButton_Click;
            this.Controls.Add(btnPlus);

            // Equals button
            this.btnEquals.Text = "=";
            this.btnEquals.Size = new System.Drawing.Size(buttonSize, buttonSize);
            this.btnEquals.Location = new System.Drawing.Point(startX + 3 * (buttonSize + spacing), startY + (buttonSize + spacing));
            this.btnEquals.Click += EqualsButton_Click;
            this.Controls.Add(btnEquals);

            // Clear button
            this.btnClear.Text = "C";
            this.btnClear.Size = new System.Drawing.Size(buttonSize, buttonSize);
            this.btnClear.Location = new System.Drawing.Point(startX + 3 * (buttonSize + spacing), startY + 2 * (buttonSize + spacing));
            this.btnClear.Click += ClearButton_Click;
            this.Controls.Add(btnClear);

            // Form settings
            this.Text = "Simple Calculator";
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(txtDisplay);
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