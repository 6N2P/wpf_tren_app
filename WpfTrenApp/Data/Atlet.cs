using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTrenApp.Data
{
    internal class Atlet
    {
        //название переменных должно быть такоеже как в БД это важно!!!
        private int ID { get; set; }
        private string Name { get; set; }
        private int Age { get; set; }
        private int Growth { get; set; }
        private int Weight { get; set; }
        private string Progtren { get; set; }

        public Atlet() { }

        public Atlet(int iD, string name, int age, int growth, int weight, string progtren)
        {
            ID = iD;
            Name = name;
            Age = age;
            Growth = growth;
            Weight = weight;
            Progtren = progtren;
        }
    }
}
