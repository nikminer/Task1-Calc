using System.Collections.ObjectModel;
using Task1_Calc.Models.Interfaces;

namespace Task1_Calc.Models
{
    internal class CalculatorMemory : PropertyChanger, ICalculatorMemory
    {
        // Обязанность класса запоминать все результаты вычислений

        // История всех вычислений
        public ObservableCollection<IResult> Results { get; set; }

        // Текущее или выбранное вычисление
        private IResult _selectedResult;
        public IResult SelectedResult
        {
            get { return _selectedResult; }
            set
            {
                _selectedResult = value;
                OnPropertyChanged("SelectedResult");
            }
        }
        
        public CalculatorMemory()
        {
            Results = new ObservableCollection<IResult>();
        }


        public void SaveResult(IResult result)
        {
            Results.Insert(0, result);
            SelectedResult = result;
        }
    }
}
