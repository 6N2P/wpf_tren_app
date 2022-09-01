using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WpfTrenApp.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Atlet> Atlets { get; set; }

        public ApplicationContext() : base("DefaultConnection") { }

                
    }
}
