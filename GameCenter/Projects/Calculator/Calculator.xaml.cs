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
using System.Windows.Shapes;

namespace GameCenter.Projects.Calculator
{
    /// <summary>
    /// Interaction logic for Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        private double _firstNumber = 0;
        private char _operator;

        public Calculator()
        {
            InitializeComponent();
        }
        //Number_Click -> display on the textBox
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            display.Text += btn.Content.ToString();
        }

        //Operation_Click -> 1. save the number 2.reset the display 3.save the operator
        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (!string.IsNullOrEmpty(btn.Content.ToString()))
            {
                _operator = btn.Content.ToString()[0];
            }
            if (!string.IsNullOrEmpty(display.Text))
            {
                _firstNumber = double.Parse(display.Text);
            }
            display.Text = "";
        }

        //Equal_Click ->1. do the calculation 2.display the result
        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(display.Text))
            {
                switch (_operator)
                {
                    case '+':
                        display.Text = (double.Parse(display.Text) + _firstNumber).ToString();
                        break;
                    case '-':
                        display.Text = (double.Parse(display.Text) - _firstNumber).ToString();
                        break;
                    case '*':
                        display.Text = (double.Parse(display.Text) * _firstNumber).ToString();
                        break;
                    case '/':
                        display.Text = (double.Parse(display.Text) / _firstNumber).ToString();
                        break;
                    default:
                        break;
                }
            }

        }


        //Clear_Click -> 1.reset display 2.clear the data (of the number)
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            display.Text = "";
            _firstNumber = 0;
            _operator = '+';
        }
    }
}
