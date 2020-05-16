using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        double numOne = 0;
        double numTwo = 0;
        string operation;
        bool scifiMode = false;
        const int widthSmall = 390;
        const int widthLarge = 660;
        public Calculator()
        {
            InitializeComponent();
            InitializeCalculator();
        }
        private void InitializeCalculator()
        {
            this.BackColor = Color.Green;
            this.Width = widthSmall;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            Display.Font = new Font("Roboto", 22f);
            Button button = null;
            string buttonName = null;
            for (int i = 0; i < 10; i++)
            {
                buttonName = "button" + i;
                button = (Button)this.Controls[buttonName];
                button.Text = i.ToString();
                button.Font = new Font("Roboto", 22f);
            }

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (Display.Text == "0")
            {
                Display.Text = button.Text;
            }
            else
            {
                Display.Text += button.Text;
            }
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            if (!Display.Text.Contains(","))
            {
                if (Display.Text == string.Empty)
                {
                    Display.Text += "0,";
                }
                else
                {
                    Display.Text += ",";
                }
            }
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            string s = Display.Text;
            if (s.Length > 1)
            {
                s = s.Substring(0, s.Length - 1);
            }
            else
            {
                s = "0";
            }
            Display.Text = s;
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            try
            {
                double number = Convert.ToDouble(Display.Text);
                number *= -1;
                Display.Text = Convert.ToString(number);
            }
            catch
            {

            }
        }
        

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void Operation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            numOne = Convert.ToDouble(Display.Text);
            if (button.Text == "√")
            {
                Display.Text = Math.Sqrt(numOne).ToString();
                return;
            }
            Display.Text = string.Empty;
            operation = button.Text;
            
        }
        private void buttonResult_Click(object sender, EventArgs e)
        {
            double result = 0; ;
            numTwo = Convert.ToDouble(Display.Text);
            if (operation == "+")
            {
                result = numOne + numTwo;
            }
            else if (operation == "-")
            {
                result = numOne - numTwo;
            }
            else if (operation == "x")
            {
                result = numOne * numTwo;
            }
            else if (operation == "/")
            {
                result = numOne / numTwo;
            }
            else if (operation == "^")
            {
                result = Math.Pow(numOne, numTwo);
            }
            Display.Text = result.ToString();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Display.Text = "0";
            numOne = 0;
            numTwo = 0;
        }

        private void buttonSciFi_Click(object sender, EventArgs e)
        {
            if (scifiMode)
            {
                this.Width = widthSmall;
            }
            else
            {
                this.Width = widthLarge;
            }
            scifiMode = !scifiMode;
        }
    }
}
