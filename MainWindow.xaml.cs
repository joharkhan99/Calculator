using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double num1 = 0, num2 = 0;
        bool isAddBtn = false, isSubtractBtn = false, isMultiplyBtn = false, isDivideBtn = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OperationButtonClicked(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b == addButton)
            {
                try
                {
                    num1 += double.Parse(outputTxt.Text);
                    label.Content = outputTxt.Text + "+";
                    outputTxt.Text = "";
                    isAddBtn = true;
                    isSubtractBtn = false;
                    isMultiplyBtn = false;
                    isDivideBtn = false;
                }
                catch (FormatException)
                {
                    label.Content = "Invalid Operation";
                }
            }
            else if (b == multButton)
            {
                try
                {

                    num1 += double.Parse(outputTxt.Text);
                    label.Content = outputTxt.Text + "x";
                    outputTxt.Text = "";
                    isAddBtn = false;
                    isSubtractBtn = false;
                    isMultiplyBtn = true;
                    isDivideBtn = false;
                }
                catch (FormatException)
                {
                    label.Content = "Invalid Operation";
                }
            }
            else if (b == subButton)
            {
                try
                {

                    num1 += double.Parse(outputTxt.Text);
                    label.Content = outputTxt.Text + "-";
                    outputTxt.Text = "";
                    isAddBtn = false;
                    isSubtractBtn = true;
                    isMultiplyBtn = false;
                    isDivideBtn = false;
                }
                catch (FormatException)
                {
                    label.Content = "Invalid Operation";
                }
            }
            else if (b == divButton)
            {
                try
                {

                    num1 += double.Parse(outputTxt.Text);
                    label.Content = outputTxt.Text + "/";
                    outputTxt.Text = "";
                    isAddBtn = false;
                    isSubtractBtn = false;
                    isMultiplyBtn = false;
                    isDivideBtn = true;
                }
                catch (FormatException)
                {
                    label.Content = "Invalid Operation";
                }
            }
        }

        private void FunctionButtonClicked(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b == CEbtn)
            {
                outputTxt.Text = "0";
                label.Content = "";
            }
            else if (b == Cbtn)
            {
                outputTxt.Text = "0";
                label.Content = "";
            }
            else if (b == Backbtn)
            {
                if (outputTxt.Text != "")
                {
                    outputTxt.Text = outputTxt.Text.Substring(0, outputTxt.Text.Length - 1);
                }
            }
        }

        private void ResultButtonClicked(object sender, RoutedEventArgs e)
        {
            if (outputTxt.Text.ToString() != null && outputTxt.Text.ToString().Trim() != "")
            {

                if (isAddBtn)
                {
                    num2 = num1 + double.Parse(outputTxt.Text);
                    label.Content = num1 + "+" + double.Parse(outputTxt.Text);
                    outputTxt.Text = num2.ToString();
                    num1 = 0;
                }
                else if (isSubtractBtn)
                {
                    num2 = num1 - double.Parse(outputTxt.Text);
                    label.Content = num1 + "-" + double.Parse(outputTxt.Text);
                    outputTxt.Text = num2.ToString();
                    num1 = 0;
                }
                else if (isMultiplyBtn)
                {
                    num2 = num1 * double.Parse(outputTxt.Text);
                    label.Content = num1 + "x" + double.Parse(outputTxt.Text);
                    outputTxt.Text = num2.ToString();
                    num1 = 0;
                }
                else if (isDivideBtn)
                {
                    num2 = num1 / double.Parse(outputTxt.Text);
                    label.Content = num1 + "/" + double.Parse(outputTxt.Text);
                    outputTxt.Text = num2.ToString();
                    num1 = 0;
                }

            }

        }

        private void NumberButtonClicked(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b == zeroButton)
                UtilityFunction("0");
            else if (b == oneButton)
                UtilityFunction("1");
            else if (b == twoButton)
                UtilityFunction("2");
            else if (b == threeButton)
                UtilityFunction("3");
            else if (b == fourButton)
                UtilityFunction("4");
            else if (b == fiveButton)
                UtilityFunction("5");
            else if (b == sixButton)
                UtilityFunction("6");
            else if (b == sevenButton)
                UtilityFunction("7");
            else if (b == eightButton)
                UtilityFunction("8");
            else if (b == nineButton)
                UtilityFunction("9");
            else if (b == decPointButton)
                UtilityFunction(".");
        }


        private void UtilityFunction(string num)
        {
            if (outputTxt.Text == "0")
            {
                outputTxt.Text = num;
            }
            else
            {
                outputTxt.Text += num;
                label.Content = outputTxt.Text;
            }
        }

        private void CubeRoot(object sender, RoutedEventArgs e)
        {
            if(outputTxt.Text.ToString()!=null && outputTxt.Text.ToString() != "")
            {
                double number = double.Parse(outputTxt.Text);
                if (number >= 0)
                {
                    label.Content = Math.Ceiling(Math.Pow(number, (double)1 / 3)); ;
                }
                else
                {
                    label.Content = "negative root not possible";
                }
            }

        }
        private void SquareRoot(object sender, RoutedEventArgs e)
        {
            if(outputTxt.Text.ToString()!=null && outputTxt.Text.ToString() != "")
            {
                double number = double.Parse(outputTxt.Text);
                if (number >= 0)
                {
                    label.Content = Math.Sqrt(number);
                }
                else
                {
                    label.Content = "negative root not possible";
                }
            }
        }
        private void Power(object sender, RoutedEventArgs e)
        {
            if(outputTxt.Text.ToString()!=null && outputTxt.Text.ToString() != "")
            {
                double number = double.Parse(outputTxt.Text);
                label.Content = number*number;
            }
        }
        private void DivideByOne(object sender, RoutedEventArgs e)
        {
            if(outputTxt.Text.ToString()!=null && outputTxt.Text.ToString() != "")
            {
                double number = double.Parse(outputTxt.Text);
                try
                {
                    label.Content = 1/number;
                }
                catch (DivideByZeroException ex)
                {
                    label.Content = "Error! Divide by 0";
                }
            }
        }

    }
}
