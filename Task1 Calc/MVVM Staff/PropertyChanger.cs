using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Task1_Calc
{
    internal class PropertyChanger: INotifyPropertyChanged
    {
        // Класс необходимый для обновления данных по паттерну MVVM
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
