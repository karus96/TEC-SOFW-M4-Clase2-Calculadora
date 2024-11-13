using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TEC_SOFW_M4_Clase_2Pre
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _currentValue = "";
        }

        string _currentValue;
        string _lastValue;
        string _operationValue;
        bool clear;
        char operation;

        public void UpdateDisplay()
        {
            Display.Text = $"{_currentValue}";
        }
        private void AddNumber(object sender, RoutedEventArgs e)
        {
            if (clear)
            {
                _currentValue = "";
                clear = false;
            }
            string buttonName = ((Button)e.Source).Name;
            _lastValue = _currentValue;
            switch (buttonName)
            {
                case "BTN0":
                    _currentValue += 0;
                    break;
                case "BTN1":
                    _currentValue += 1;
                    break;
                case "BTN2":
                    _currentValue += 2;
                    break;
                case "BTN3":
                    _currentValue += 3;
                    break;
                case "BTN4":
                    _currentValue += 4;
                    break;
                case "BTN5":
                    _currentValue += 5;
                    break;
                case "BTN6":
                    _currentValue += 6;
                    break;
                case "BTN7":
                    _currentValue += 7;
                    break;
                case "BTN8":
                    _currentValue += 8;
                    break;
                case "BTN9":
                    _currentValue += 9;
                    break;
                case "BTNDot":
                    _currentValue += ".";
                    break;
            }
            UpdateDisplay();
        }
        private void ActionC(object sender, RoutedEventArgs e)
        {
            _currentValue = "";
            Display.Text = $"{_currentValue}";
        }
        private void ActionDelete(object sender, RoutedEventArgs e)
        {
            try
            {
                _currentValue = _currentValue.Remove(_currentValue.Length - 1);
                UpdateDisplay();
            }
            catch (ArgumentOutOfRangeException) { }

        }
        private void ActionPercentage(object sender, RoutedEventArgs e)
        {
            double previousValue = double.Parse(_lastValue);
            double currentValue = double.Parse(_currentValue);
            try
            {
                if (previousValue != 0)
                {
                    currentValue = (previousValue * currentValue) / 100;
                }
                UpdateDisplay();
            }
            catch (FormatException) { }

        }
        private void ActionOperation(object sender, RoutedEventArgs e)
        {
            string buttonName = ((Button)e.Source).Name;
            clear = true;
            _operationValue = _currentValue;
            switch (buttonName)
            {
                case "BTNDivide":
                    _currentValue = $"/";
                    operation = '/';
                    break;
                case "BTNX":
                    _currentValue = $"*";
                    operation = '*';
                    break;
                case "BTNLess":
                    _currentValue = $"-";
                    operation = '-';
                    break;
                case "BTNAdd":
                    _currentValue = $"+";
                    operation = '+';
                    break;              
            }            
            UpdateDisplay();        
        }
        private void ActionX(object sender, RoutedEventArgs e)
        {
            clear = true;
            _operationValue = _currentValue;
            _currentValue = $"*";
            operation = '*';
            UpdateDisplay();
        }
        private void ActionEqual(object sender, RoutedEventArgs e)
        {
            double operationValue = 0;
            double currentValue =0;
            try {
                operationValue = double.Parse(_operationValue);
                currentValue = double.Parse(_currentValue);
            }
            catch (FormatException) 
            {
                _operationValue = "0";
                _currentValue = "0";
            }        
            
            switch (operation) {
                case '/':
                    try
                    {
                        _currentValue = $"{operationValue / currentValue}";
                    }
                    catch (DivideByZeroException)
                    {
                        _currentValue = "NAN";
                    }                    
                    break;
                case '+':
                    _currentValue = $"{operationValue + currentValue}";
                    break;
                case '*':
                    _currentValue = $"{operationValue * currentValue}";
                    break;
                case '-':
                    _currentValue = $"{operationValue - currentValue}";
                    break;
            }
            clear = true;
            UpdateDisplay();
        }
    }
}