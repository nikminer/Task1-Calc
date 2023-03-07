using System.Collections.ObjectModel;

namespace Task1_Calc.Models.Interfaces
{
    internal interface ICalculatorMemory
    {
        public ObservableCollection<IResult> Results { get; set; }
        public IResult SelectedResult { get; set; }

        public void SaveResult(IResult result);
    }
}
