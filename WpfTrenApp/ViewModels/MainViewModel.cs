using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;
using WpfTrenApp.Data;
using WpfTrenApp.Views;

namespace WpfTrenApp.ViewModels
{
    public class MainViewModel : PropertyChangeBase
    {      

        ApplicationContext db;

        #region Properti
        public ObservableCollection<Atlet> Atlets { get; set; }
        private DateTime _dateNaw;
        public DateTime DateNaw
        {
            get => _dateNaw;
            set { _dateNaw = value; 
                OnPropertyChanged(nameof(DateNaw)); }
        }

        private double _amountCalriesNeededMass;
        public double AmountCalriesNeededMass
        
        { get => _amountCalriesNeededMass;
            set { _amountCalriesNeededMass = value;
                //NameUser=MainWindow.ListAtlet
                OnPropertyChanged(nameof(AmountCalriesNeededMass));
            }
        }

        private string name;
        public string NameUser
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("NameUser");
            }
        }


        #endregion Properti

        #region Команды
        private RelayCommand openCreateUserWindow;
        public RelayCommand OpenCreateUserWindow
        {
            get
            {
                return openCreateUserWindow ??
                    (openCreateUserWindow = new RelayCommand(obj =>
                   {
                       CreateUserWindow1 userWindow = new CreateUserWindow1();
                       userWindow.ShowDialog();
                   }));
            }
        }

        
       
        #endregion Команды

        /// <summary>
        /// конструктор
        /// </summary>
        public MainViewModel()
        {
            DateNaw = DateTime.Now;
            //db = new ApplicationContext();
            
            //db.Atlets.Load();
            //Atlets = db.Atlets.Local;


        }
    }
}
