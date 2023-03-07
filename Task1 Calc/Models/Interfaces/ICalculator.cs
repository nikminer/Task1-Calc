using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Calc.Models.Interfaces
{
    internal interface ICalculator
    {
        public ICalculatorMemory CalculatorMemory { get; }
        public ICalculatorInputProcessor CalculatorInput { get; }

        public void Calculate();
    }
}
