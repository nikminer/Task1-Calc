using System.Windows;
using System.Windows.Controls;
using Task1_Calc.ViewModels;

namespace Task1_Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new CalculatorVM();
            InitializeComponent();
        }
    }
}
