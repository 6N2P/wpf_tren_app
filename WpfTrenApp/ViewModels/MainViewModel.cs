using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfTrenApp.Data;
using WpfTrenApp.Views;

namespace WpfTrenApp.ViewModels
{
    public class MainViewModel : PropertyChangeBase
    {      

        ApplicationContext db;

        private DateTime _dateNaw;
        public DateTime DateNaw
        {
            get => _dateNaw;
            set { _dateNaw = value; OnPropertyChanged(nameof(DateNaw)); }
        }

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
        }
    }
}
