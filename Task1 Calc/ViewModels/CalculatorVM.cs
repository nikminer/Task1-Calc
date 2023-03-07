using System;
using System.Windows;
using Task1_Calc.Models;
using Task1_Calc.Models.Interfaces;

namespace Task1_Calc.ViewModels
{
    internal class CalculatorVM : PropertyChanger
    {
        // Обязанность этого класса быть связующим звеном между отображением и моделью
        public ICalculator Calculator { get; set; }
       
        public CalculatorVM()
        {
            Calculator = new NotationCalculator();
        }

        #region Commands
        // Команда меняющая полярность текущего числа
        private CalcCommand _negativeCommand;
        public CalcCommand NegativeCommand
        {
            get
            {
                return _negativeCommand ??
                  (_negativeCommand = new CalcCommand(obj => Calculator.CalculatorInput.NegativeLastNumber()));
            }
        }

        // Команда добавления операции в текущее вычисление
        private CalcCommand _addCommand;
        public CalcCommand AddCommand
        {
            get
            {
                return _addCommand ??
                  (_addCommand = new CalcCommand(obj => Calculator.CalculatorInput.AddSymbol(char.Parse((string)obj))));
            }
        }

        // Команда очистки всего буфера и текущего вычисления 
        private CalcCommand _delAllCommand;
        public CalcCommand DelAllCommand
        {
            get
            {
                return _delAllCommand ??
                  (_delAllCommand = new CalcCommand(obj => Calculator.CalculatorInput.DeleteAll()));
            }
        }

        // Команда удаления последних символов буфера
        private CalcCommand _delLastCommand;
        public CalcCommand DelLastCommand
        {
            get
            {
                return _delLastCommand ??
                  (_delLastCommand = new CalcCommand(obj => Calculator.CalculatorInput.DeleteLast()));
            }
        }

        // Команда вычисления
        private CalcCommand calcCommand;
        public CalcCommand CalcResultCommand
        {
            get
            {
                return calcCommand ??
                    (calcCommand = new CalcCommand(obj =>
                    {
                        try
                        {
                            Calculator.Calculate();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Calc", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }));
            }
        }

        #endregion Commands
    }
}
