using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTrenApp.Data;
using WpfTrenApp.Views;

namespace WpfTrenApp.ViewModels
{
    public class CreateUserViewModel : PropertyChangeBase
    {
        ApplicationContext db;

        #region Property
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
        public int Weight
        {
            get => weight;
            set
            {
                weight = value;
                OnPropertyChanged("Weight");
            }
        }
        public int Activity
        {
            get => activity;
            set
            {
                activity = value;
                OnPropertyChanged("Activity");
            }
        }

        private string name;
        private DateTime birthdey;
        private int growth;
        private int weight;
        private int activity;

        #endregion Property

        #region Comman
        private RelayCommand createAtlet;
        public RelayCommand CreateAtlet
        {
            get
            {
                return createAtlet ??
                    (createAtlet = new RelayCommand(obj =>
                    {
                        int ageNow = Atlet.GetAge(Birthdey);
                        Atlet user = new Atlet(NameUser, ageNow, Growth, Weight, "M4");
                        db.Atlets.Add(user);
                        db.SaveChanges();
                    }));
            }
        }
        #endregion Command
        public CreateUserViewModel()
        {           

            NameUser = "Плюшевая борода";
            DateTime dateNow = DateTime.Now;
            Birthdey =  dateNow;
            Growth = 180;
            Weight = 80;
            Activity = 2;

            db = new ApplicationContext();
            
        }
    }
}
