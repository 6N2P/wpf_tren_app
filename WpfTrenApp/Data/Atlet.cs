using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public double Activity { get; set; }

        public Atlet() { }

        public Atlet( string name, int age, int growth, int weight, string progtren, double activity)
        {
            
            Name = name;
            Age = age;
            Growth = growth;
            Weight = weight;
            Progtren = progtren;
            Activity = activity;
        }

        public static int GetAge(DateTime birthDate)
        {
            var now = DateTime.Today;
            return now.Year - birthDate.Year - 1 +
                ((now.Month > birthDate.Month || now.Month == birthDate.Month && now.Day >= birthDate.Day) ? 1 : 0);
        }
        public static double CoafficintActivity(int selectActivity)
        {
            double coafficient = 1;

            switch(selectActivity)
            {
                case 0:
                    coafficient = 1.2;
                    break;
                case 1:
                    coafficient = 1.375;
                    break;
                case 2:
                    coafficient = 1.55;
                    break;
                case 3:
                    coafficient = 1.725;
                    break;
                case 4:
                    coafficient = 1.9;
                    break;
            }

            return coafficient;
        }
    }
}
