using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTrenApp.Data;

namespace WpfTrenApp.ViewModels
{
    public class CreateFoodViewModel : PropertyChangeBase
    {
        private ApplicationContext db;

        #region Property
        
        private string foodName;
        private int proteins;
        private int fats;
        private int carbohydrates;
        private int calories;

        public string FoodName
        {
            get => foodName;
            set
            {
                foodName = value;
                OnPropertyChanged("FoodName");
            }
        }

        public int Proteins
        {
            get => proteins;
            set
            {
                proteins = value;
                OnPropertyChanged("Proteins");
            }
        }

        public int Fats
        {
            get => fats;
            set
            {
                fats = value;
                OnPropertyChanged("Fats");
            }
        }

        public int Carbohydrates
        {
            get => carbohydrates;
            set
            {
                carbohydrates = value;
                OnPropertyChanged("Carbohydrates");
            }
        }

        public int Calories
        {
            get => calories; set
            {
                calories = value;
                OnPropertyChanged("Calories");
            }
        }
        #endregion Property

        #region Command

        private RelayCommand createFood;

        public RelayCommand CreateFood
        {
            get
            {
                return createFood ??
                       (createFood = new RelayCommand(obj =>
                       {
                           Food food = new Food(foodName, proteins, fats, carbohydrates, calories);
                           db.Foods.Add(food);
                           db.SaveChanges();
                       }));
            }
        }

        public CreateFoodViewModel()
        {
            FoodName = "Картошка";
            Proteins = 0;
            Fats=0;
            Carbohydrates = 0;
            Calories = 0;

            db = new ApplicationContext();
        }

        #endregion
    }
}
