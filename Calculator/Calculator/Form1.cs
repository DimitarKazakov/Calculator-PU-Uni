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
    public partial class calculatorForm : Form
    {
        private double memory = 0;
        public calculatorForm()
        {
            InitializeComponent();
        }

        private void oneBtn_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += '1';
        }

        private void twoBtn_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += '2';
        }

        private void threeBtn_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += '3';
        }

        private void fourBtn_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += '4';
        }

        private void fiveBtn_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += '5';
        }

        private void sixBtn_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += '6';
        }

        private void sevenBtn_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += '7';
        }

        private void eightBtn_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += '8';
        }

        private void nineBtn_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += '9';
        }

        private void zeroBtn_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += '0';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void mRecallBtn_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.memory.ToString();
        }

        private void mClearBtn_Click(object sender, EventArgs e)
        {
            this.memory = 0;
            this.textBox1.Text = string.Empty;
        }

        private void mMinusBtn_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length == 0)
            {
                return;
            }

            if (this.textBox1.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length > 1)
            {
                return;
            }
            var input = double.Parse(this.textBox1.Text);
            this.memory -= input;
            this.textBox1.Text = string.Empty;
        }

        private void mPlusBtn_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length == 0)
            {
                return;
            }
            if (this.textBox1.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length > 1)
            {
                return;
            }
            var input = double.Parse(this.textBox1.Text);
            this.memory += input;
            this.textBox1.Text = string.Empty;
        }

        private void sqrtBtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateOperation())
            {
                return;
            }
            this.textBox1.Text += "sqrt";
        }

        private void divideBtn_Click(object sender, EventArgs e)
        {
            if (!this.ValidateOperation())
            {
                return;
            }
            

            this.textBox1.Text += " / ";
        }

        private void multiplyBtn_Click(object sender, EventArgs e)
        {
            if (!this.ValidateOperation())
            {
                return;
            }

            this.textBox1.Text += " * ";
        }

        private void minusBtn_Click(object sender, EventArgs e)
        {
            if (!this.ValidateOperation())
            {
                return;
            }
            
            this.textBox1.Text += " - ";
        }

        private void plusBtn_Click(object sender, EventArgs e)
        {
            if (!this.ValidateOperation())
            {
                return;
            }
            
            this.textBox1.Text += " + " ;

        }

        private void dotBtn_Click(object sender, EventArgs e)
        {
            if (!this.ValidateOperation())
            {
                return;
            }

            this.textBox1.Text += '.';
        }

        private void equalsBtn_Click(object sender, EventArgs e)
        {
            if (!this.ValidateOperation())
            {
                return;
            }

            var input = this.textBox1.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (input.Length < 3 && !input[0].StartsWith("sqrt"))
            {
                return;
            }

            var result = this.Parsedouble(input[0]);
            for (int i = 1; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case "+":
                        result += this.Parsedouble(input[i + 1]);
                        i++;
                        break;
                    case "-":
                        result -= this.Parsedouble(input[i + 1]);
                        i++;
                        break;
                    case "/":
                        result /= this.Parsedouble(input[i + 1]);
                        i++;
                        break;
                    case "*":
                        result *= this.Parsedouble(input[i + 1]);
                        i++;
                        break;
                    default:
                        break;
                }
            }

            this.textBox1.Text = result.ToString();
        }

        private bool ValidateOperation()
        {
            var input = this.textBox1.Text;
            if (input.Length == 0)
            {
                return false;
            }
            double lastNumber;
            return double.TryParse(input[input.Length - 1].ToString(), out lastNumber);
        }

        private double Parsedouble(string input)
        {
            if (input.StartsWith("sqrt"))
            {
                input = input.Replace("sqrt", string.Empty);
                return Math.Sqrt(double.Parse(input));
            }

            return double.Parse(input);
        }

        private void calculatorForm_Load(object sender, EventArgs e)
        {

        }

        private void cleantBtnCalc_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = string.Empty;
        }
    }
}
