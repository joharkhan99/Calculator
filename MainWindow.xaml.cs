using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Operations op = new Operations();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumOpButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            displayTextbox.Text += b.Content.ToString();
        }
        private void calcButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Calculate();
        }
            catch (Exception excep)
            {
                displayTextbox.Text = "Error! "+excep.Message;
            }
}

        private void FuncButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == clearButton)
            {
                displayTextbox.Text = "";
            }
        }

        public void Calculate()
        {
            int operationPosition = 0;
            string operation = "";
            double num1 = 0, num2 = 0, result = 0;

            if (displayTextbox.Text.Contains("x"))
            {
                operationPosition = displayTextbox.Text.IndexOf("x");
            }
            else if (displayTextbox.Text.Contains("/"))
            {
                operationPosition = displayTextbox.Text.IndexOf("/");
            }
            else if (displayTextbox.Text.Contains("+"))
            {
                operationPosition = displayTextbox.Text.IndexOf("+");
            }
            else if (displayTextbox.Text.Contains("-"))
            {
                operationPosition = displayTextbox.Text.IndexOf("-");
            }

            num1 = Double.Parse(displayTextbox.Text.Substring(0, operationPosition));
            operation = displayTextbox.Text.Substring(operationPosition, 1);
            num2 = Double.Parse(displayTextbox.Text.Substring(operationPosition + 1, displayTextbox.Text.Length - operationPosition - 1));

            if (operation == "x")
            {
                result = op.multiply(num1, num2);
                displayTextbox.Text += "= " + result.ToString();
            }
            else if (operation == "/")
            {
                if (num2 == 0)
                {
                    displayTextbox.Text = "Divide by zero error!";
                }
                else
                {
                    result = op.divide(num1, num2);
                    displayTextbox.Text += "= " + result.ToString();
                }
            }
            else if (operation == "+")
            {
                result = op.add(num1, num2);
                displayTextbox.Text += "= " + result.ToString();
            }
            else if (operation == "-")
            {
                result = op.subtract(num1, num2);
                displayTextbox.Text += "= " + result.ToString();
            }
        }


    }
}
