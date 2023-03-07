using System;
using System.Collections.Generic;
using Task1_Calc.Models.Common;
using Task1_Calc.Models.Enums;
using Task1_Calc.Models.Interfaces;

namespace Task1_Calc.Models.Static
{
    // Обязанность класса преобразовать входную строку в польскую нотацию
    static internal class NotationInputParser
    {
        public static void Parse(IResult result)
        {
            Stack<string> stack = new Stack<string>();
            string output = string.Empty;

            // Удаляем лишние пробелы
            result.InputStr = result.InputStr.Trim();

            // Перебираем входную строку разделив каждое слово в строке
            foreach (string input in result.InputStr.Split(' '))
            {
                WordTypes type = NotationHelper.GetWordType(input);

                // Если слово является числом, добавляем его к выходной строке.
                if (type == WordTypes.Num)
                {
                    output += $" {input}";
                    continue;
                }

                // Если символ является префиксной функцией или постфиксной функцией или открывающей скобкой, помещаем его в стек.
                if (type == WordTypes.Prefix || type == WordTypes.Postfix || type == WordTypes.Open)
                {
                    stack.Push(input);
                    continue;
                }

                // Если символ является закрывающей скобкой, перебираем весь стек пока не найдём открывающую скобку
                if (type == WordTypes.Close)
                {
                    while (stack.Count > 0)
                    {
                        string value = stack.Pop();

                        if (NotationHelper.GetWordType(value) == WordTypes.Open)
                        {
                            break;
                        }

                        output += $" {value}";

                        // Если не нашли скобку, то выкидываем ошибку
                        if (stack.Count == 0)
                        {
                            throw new ArithmeticException("В выражении не согласованы скобки.");
                        }
                    }
                }
            }

            // Выгружаем оставшиеся символы из сека
            while (stack.Count > 0)
            {
                string value = stack.Pop();
                output += $" {value}";
            }

            result.PolishStr = output.TrimStart();
        }
    }
}
