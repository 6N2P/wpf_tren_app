using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTrenApp.ViewModels
{
    public class CreateUserViewModel : PropertyChangeBase
    {
        public string NameUser 
        { get => name;
            set
            {
                name = value;
                OnPropertyChanged("NameUser");
            }
        }
        public DateTime Birthdey
        { get => birthdey;
            set 
            { 
                birthdey = value;
                OnPropertyChanged("Birthdey");
            }
        }
        public int Growth 
        { get => growth;
            set {
                growth = value;
                OnPropertyChanged("Growth");
            }
        }
        public double Weight { get => weight; set => weight = value; }
        public int Activity { get => activity; set => activity = value; }

        private string name;
        private DateTime birthdey;
        private int growth;
        private double weight;
        private int activity;

        public CreateUserViewModel()
        {
            DateTime dateNow = DateTime.Now;
            Birthdey =  dateNow;
        }
    }
}
