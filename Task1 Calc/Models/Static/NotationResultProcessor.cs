using System;
using System.Collections.Generic;
using Task1_Calc.Models.Common;
using Task1_Calc.Models.Enums;
using Task1_Calc.Models.Interfaces;

namespace Task1_Calc.Models.Static
{
    // Обязанность класса подсчитать конечный результат на основе польской нотации
    internal static class NotationResultProcessor
    {
        public static void Calculate(IResult result)
        {
            Stack<double> stack = new Stack<double>();

            // Перебираем строку с польской нотацией
            foreach (string input in result.PolishStr.Split(' '))
            {
                WordTypes type = NotationHelper.GetWordType(input);

                // Если слово - это число, то преобразуем в число добавляем в стак
                if (type == WordTypes.Num)
                {
                    stack.Push(double.Parse(input));
                    continue;
                }

                // Если слово - это префикс, то выполняем операцию над числом
                if (type == WordTypes.Prefix)
                {
                    // Пытаемся получить число из стека
                    double i;

                    if (!stack.TryPop(out i))
                    {
                        continue;
                    }

                    switch (input)
                    {
                        case "√":
                            stack.Push(Math.Sqrt(i));
                            break;
                        default:
                            throw new NotImplementedException(input);
                    }
                    continue;
                }

                // Если слово - это постфикс, то выполняем операцию над числами
                if (type == WordTypes.Postfix)
                {
                    double i1;
                    double i2;

                    // Пытаемся получить числа из стека, если есть только одно число то считаем что второе равно нулю
                    if (!stack.TryPop(out i2))
                    {
                        continue;
                    }

                    if (!stack.TryPop(out i1))
                    {
                        i1 = 0;
                    }

                    switch (input)
                    {
                        case "+":
                            stack.Push(i1 + i2);
                            break;
                        case "-":
                            stack.Push(i1 - i2);
                            break;
                        case "*":
                            stack.Push(i1 * i2);
                            break;
                        case "/":
                            if (i2 == 0)
                            {
                                throw new ArithmeticException("Деление на ноль!");
                            }
                            stack.Push(i1 / i2);
                            break;

                        case "^":
                            stack.Push(Math.Pow(i1, i2));
                            break;
                        default:
                            throw new NotImplementedException(input);
                    }

                    continue;
                }

            }

            // Самое верхнее число стека является результатом вычислений,
            // если вдруг стек пуст, то результат 0,
            // если в стаке остались числа, то игнорируем их
            if (stack.Count > 0)
            {
                result.ResultCalc = stack.Pop();
            }
            else
            {
                result.ResultCalc = 0;
            }
        }
    }
}
