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
        public ObservableCollection<Food> Foods { get; set; }

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
                if (selectedAtlet != null)
                {
                    AmountCalriesNeededMass = Math.Round(Calorie.CalorieCalculation
                        (selectedAtlet.Weight, selectedAtlet.Age, selectedAtlet.Growth, selectedAtlet.Activity), 0);
                    AmountCfloriesNeededNaw = Math.Round(Calorie.CalorieCalculationNorm
                        (selectedAtlet.Weight, selectedAtlet.Age, selectedAtlet.Growth, selectedAtlet.Activity), 0);
                }
                OnPropertyChanged(nameof(SelectedAtlet));
            }
        }

        private Food selectedFood;

        public Food SelectedFood
        {
            get => selectedFood;
            set
            {
                selectedFood=value;
                OnPropertyChanged(nameof(SelectedFood));
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
        /// <summary>
        /// команда открывания окна для создания атлета
        /// </summary>
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

        private RelayCommand openCreateFoodWindow;

        public RelayCommand OpenCreateFoodWindow
        {
            get
            {
                return openCreateFoodWindow ??
                       (openCreateFoodWindow = new RelayCommand(obj =>
                       {
                           CreateFoodWindow foodWindow = new CreateFoodWindow();
                           foodWindow.ShowDialog();
                       }));
            }
        }
        private RelayCommand updateViewAtlets;
        /// <summary>
        /// команда обновления списка атлетов в veiw
        /// </summary>
        public RelayCommand UpdateViewAtlets
        {
            get
            {
                return updateViewAtlets ??
                    (updateViewAtlets = new RelayCommand(obj =>
                    {
                        db.SaveChanges();
                        db.Atlets.Load();
                    }));
            }
        }

        private RelayCommand updateViewFoods;

        public RelayCommand UpdateViewFoods
        {
            get
            {
                return updateViewFoods ??
                       (updateViewFoods = new RelayCommand(obj =>
                       {
                           db.SaveChanges();
                           db.Foods.Load();
                       }));
            }
        }
        private RelayCommand clouseDb;
        public RelayCommand ClouseDb
        {
            get
            {
                return clouseDb ??
                    (clouseDb = new RelayCommand(obj =>
                    {
                        db.Dispose();
                    }));
            }
        }

        private RelayCommand deletAtletOnView;
        /// <summary>
        /// команда удаления атлета из спискад
        /// </summary>
        public RelayCommand DeletAtletOnView
        {
            get
            {
                return deletAtletOnView ??
                    (deletAtletOnView = new RelayCommand(obj =>
                    {
                        if (Atlets.Count > 0)
                        {
                            for (int i = 0; i < Atlets.Count; i++)
                            {
                                Atlet atlet = selectedAtlet as Atlet;
                                if (atlet != null)
                                {
                                    db.Atlets.Remove(atlet);
                                }
                            }
                        }
                        db.SaveChanges();
                    }));
            }
        }

        private RelayCommand deletFoodOnView;

        public RelayCommand DletFoodOnView
        {
            get
            {
                return deletFoodOnView ??
                       (deletFoodOnView = new RelayCommand(obj =>
                       {
                           if (Foods.Count > 0)
                               for (int i = 0; i < Foods.Count; i++)
                               {
                                   Food food = selectedFood as Food;
                                   if (food != null)
                                   {
                                       db.Foods.Remove(food);
                                   }
                               }

                           db.SaveChanges();
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

            db.Foods.Load();
            Foods=new ObservableCollection<Food>();
            Foods = db.Foods.Local;
           
        }
    }
}
