using Task1_Calc.Models.Interfaces;
using Task1_Calc.Models.Static;

namespace Task1_Calc.Models
{
    internal class NotationCalculator: ICalculator
    {
        // Обязанность этого класса обработать и подсчитать реультат
        public ICalculatorMemory CalculatorMemory { get; }
        public ICalculatorInputProcessor CalculatorInput { get; }

        public NotationCalculator()
        {
            CalculatorInput = new CalculatorInputProcessor();
            CalculatorMemory = new CalculatorMemory();
        }

        public void Calculate()
        {
            // Если ничего не введено то выходим
            if (CalculatorInput.CurrentResult.InputStr.Length == 0)
            {
                return;
            }

            IResult result = CalculatorInput.CurrentResult;
            NotationInputParser.Parse(result);
            NotationResultProcessor.Calculate(CalculatorInput.CurrentResult);

            CalculatorMemory.SaveResult(CalculatorInput.CurrentResult);

            CalculatorInput.DeleteAll();
        }
    }
}
