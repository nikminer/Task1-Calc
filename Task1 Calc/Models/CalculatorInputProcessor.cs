using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Task1_Calc.Models.Interfaces;

namespace Task1_Calc.Models
{
    // Обязанность класса считывая входящие символы формируя входную строку для последующего парсинга
    internal class CalculatorInputProcessor: PropertyChanger, ICalculatorInputProcessor
    {
        // Буфер для хранения текущего вычисления 
        private IResult _currentResult;
        public IResult CurrentResult
        {
            get { return _currentResult; }
            set
            {
                _currentResult = value;
                OnPropertyChanged("CurrentResult");
            }
        }

        public CalculatorInputProcessor()
        {
            CurrentResult = new Result();
        }

        public void DeleteAll()
        {
            CurrentResult = new Result();
        }

        public void DeleteLast()
        {
            if (CurrentResult.InputStr.Length > 0)
            {
                CurrentResult.InputStr = CurrentResult.InputStr.Remove(CurrentResult.InputStr.Length - 1).TrimEnd();
            }
        }

        public void AddSymbol(char input)
        {
            string injectionStr = $" {input}";

            // Введено ли число и есть ли на конце число или точка? Если да то добавить без пробела
            bool isLastNumberOrDot = CurrentResult.InputStr.Length > 0 && (char.IsNumber(CurrentResult.InputStr.Last()) || CurrentResult.InputStr.Last() == ',');

            if (char.IsNumber(input) && isLastNumberOrDot)
            {
                injectionStr = injectionStr.TrimStart();
            }

            if (input == '(' && CurrentResult.InputStr.Length != 0 && char.IsNumber(CurrentResult.InputStr.Last()))
            {
                return;
            }

            // Введенна ли точка и есть ли на конце число или точка? Если да, то добавить без пробела
            bool isDot = input == ',';

            if (isDot && isLastNumberOrDot)
            {
                // Есть ли уже точка? Если да, то ничего не делать
                if (CurrentResult.InputStr.Split(' ').Last().Contains(','))
                {
                   return;
                }

                injectionStr = injectionStr.TrimStart();
            }
            // Иначе ничего не делать
            else if (isDot && !isLastNumberOrDot)
            {
                return;
            }


            CurrentResult.InputStr += injectionStr;
        }

        public void NegativeLastNumber()
        {
            // Получаем последние символы
            string number = CurrentResult.InputStr.Split(' ').Last();

            if (ValidateNegativeNumber(number))
            {
                // Удаляем полученные символы
                CurrentResult.InputStr = CurrentResult.InputStr.Remove(CurrentResult.InputStr.LastIndexOf(number), number.Length);

                // Если имеется отрицательное значение то просто затираем первый символ, иначе добавляет отрицательньный знак
                if (number[0] == '-')
                {
                    number = number.Remove(0, 1);
                }
                else
                {
                    number = $"-{number}";
                }
                // Дописываем число
                CurrentResult.InputStr += number;
            }
        }

        private bool ValidateNegativeNumber(string number)
        {
            // Если символы содержат что-то и первый или второй символ это число
            bool isValid = (number.Length > 1  && char.IsNumber(number[1]))
                        || (number.Length == 1 && char.IsNumber(number[0]));

            return isValid;
        }

    }
}
