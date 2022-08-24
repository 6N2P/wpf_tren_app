using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfTrenApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private DateTime _dateNaw;
        public DateTime DateNaw
        {
            get => _dateNaw;
            set { _dateNaw = value; OnPropertyChanged(nameof(DateNaw)); }
        }
         public MainViewModel()
        {

            DateNaw = DateTime.Now;
        }
    }
}
