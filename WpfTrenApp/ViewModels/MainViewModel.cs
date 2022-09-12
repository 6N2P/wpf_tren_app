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
using System.Windows.Input;
using System.Xml.Linq;
using WpfTrenApp.Data;
using WpfTrenApp.Views;

namespace WpfTrenApp.ViewModels
{
    public class MainViewModel : PropertyChangeBase
    {      

        ApplicationContext db;

        #region Properti
        //считывает из бд Атлетов
        public ObservableCollection<Atlet> Atlets { get; set; }

        private Atlet selectedAtlet;
        /// <summary>
        /// Выбраный атлет
        /// </summary>
        public Atlet SelectedAtlet
        {
            get { return selectedAtlet; }
            set
            {
                selectedAtlet = value;
                AmountCalriesNeededMass =Math.Round( Calorie.CalorieCalculation
                    (selectedAtlet.Weight, selectedAtlet.Age, selectedAtlet.Growth, selectedAtlet.Activity),0);
                AmountCfloriesNeededNaw = Math.Round(Calorie.CalorieCalculationNorm
                    (selectedAtlet.Weight, selectedAtlet.Age, selectedAtlet.Growth, selectedAtlet.Activity), 0);
                OnPropertyChanged(nameof(SelectedAtlet));
            }
        }

        private DateTime _dateNaw;
        /// <summary>
        /// Считывает настоящую дату
        /// </summary>
        public DateTime DateNaw
        {
            get => _dateNaw;
            set { _dateNaw = value; 
                OnPropertyChanged(nameof(DateNaw)); }
        }

        private double _amountCalriesNeededMass;
        /// <summary>
        /// Отображает число каллорий необходимых для набора массы
        /// </summary>
        public double AmountCalriesNeededMass

        {
            get => _amountCalriesNeededMass;
            set
            {
                _amountCalriesNeededMass = value;
                OnPropertyChanged(nameof(AmountCalriesNeededMass));
            }
        }

        private double _amountCfloriesNeededNaw;
        /// <summary>
        /// Отображает необходимое колличество каллорий для поддержания массы
        /// </summary>
        public double AmountCfloriesNeededNaw
        {
            get => _amountCfloriesNeededNaw;
            set
            {
                _amountCfloriesNeededNaw = value;
                OnPropertyChanged(nameof(AmountCfloriesNeededNaw));
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
            db = new ApplicationContext();
            db.Atlets.Load();
            Atlets = new ObservableCollection<Atlet>();
            Atlets = db.Atlets.Local;
           

        }
    }
}
