using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Calc.Models.Interfaces
{
    internal interface ICalculatorInput
    {
        public IResult CurrentResult { get; set; }
    }
}
