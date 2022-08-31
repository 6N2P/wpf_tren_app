using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTrenApp.Data
{
    public class Atlet
    {
        //название переменных должно быть такоеже как в БД это важно!!!
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Growth { get; set; }
        public int Weight { get; set; }
        public string Progtren { get; set; }

        public Atlet() { }

        public Atlet( string name, int age, int growth, int weight, string progtren)
        {
            
            Name = name;
            Age = age;
            Growth = growth;
            Weight = weight;
            Progtren = progtren;
        }

        public static int GetAge(DateTime birthDate)
        {
            var now = DateTime.Today;
            return now.Year - birthDate.Year - 1 +
                ((now.Month > birthDate.Month || now.Month == birthDate.Month && now.Day >= birthDate.Day) ? 1 : 0);
        }
        
    }
}
