
using Task1_Calc.Models.Interfaces;

namespace Task1_Calc.Models
{
    internal class Result : PropertyChanger, IResult
    {

        // Польская нотация
        private string _polish = string.Empty;
        public string PolishStr
        {
            get { return _polish; }
            set
            {
                _polish = value;
                OnPropertyChanged("PolishStr");
            }
        }

        // Результат вычисления
        private double _result;
        public double ResultCalc
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged("ResultCalc");
            }
        }

        // Введённая пользователем последовательность
        private string _input = string.Empty;
        public string InputStr
        {
            get { return _input; }
            set
            {
                _input = value;
                OnPropertyChanged("InputStr");
            }
        }
    }

}
