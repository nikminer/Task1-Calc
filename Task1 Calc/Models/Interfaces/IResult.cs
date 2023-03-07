using System;

namespace Task1_Calc.Models.Interfaces
{
    internal interface IResult
    {
        public string InputStr { get; set; }
        public double ResultCalc { get; set; }

        public string PolishStr { get; set; }
    }
}
