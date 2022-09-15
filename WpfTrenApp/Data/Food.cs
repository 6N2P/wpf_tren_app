using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTrenApp.Data
{
    public class Food
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Proteins { get; set; }
        public int Fats { get; set; }
        public int Carbohydrates { get; set; }
        public int Calories { get; set; }

        public Food() {}

        public Food( string name, int proteins, int fats, int carbohydrates, int calories)
        {
            
            Name = name;
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
            Calories = calories;
        }
    }
}
