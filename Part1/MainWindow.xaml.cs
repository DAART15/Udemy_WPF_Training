using System.Windows;
using System.Windows.Controls;

namespace Part1
{
    public partial class MainWindow : Window
    {
        double firstNumber, result;
        string selectedOperator = "";
        
        public MainWindow()
        {
            InitializeComponent();

            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            persantageButton.Click += PersantageButton_Click;
            calculateButton.Click += CalculateButton_Click;
            commaButton.Click += CommaButton_Click;
        }

        private void CommaButton_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString()!.Contains(','))
            {
                resultLabel.Content += ",";
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            double secondNumber;
            secondNumber = double.Parse(resultLabel.Content.ToString()!);
            result = selectedOperator switch
            {
                "+" => firstNumber + secondNumber,
                "-" => firstNumber - secondNumber,
                "*" => firstNumber * secondNumber,
                "/" => secondNumber != 0 ? firstNumber / secondNumber : 0,
                _ => 0
            };
            firstNumberLabel.Content = "";
            operatorLabel.Content = "";
            resultLabel.Content = result.ToString();
        }

        private void PersantageButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber = tempNumber / 100;
                if (firstNumber != 0)
                    tempNumber *= firstNumber;
                resultLabel.Content = tempNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out firstNumber))
            {
                firstNumber = firstNumber * -1;
                resultLabel.Content = firstNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            firstNumberLabel.Content = "";
            resultLabel.Content = "0";
            result = 0;
            firstNumber = 0;
        }
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            selectedOperator = button!.Content.ToString()!;
            if (double.TryParse(resultLabel.Content.ToString(), out firstNumber))
            {
                operatorLabel.Content = selectedOperator;
                if(result.ToString() == "")
                    firstNumberLabel.Content = result.ToString();
                else 
                    firstNumberLabel.Content = firstNumber;
                resultLabel.Content = "0";
            }
        }
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            string selectedValue = button!.Content.ToString()!;
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content += $"{selectedValue}";
            }
        }
    }
}