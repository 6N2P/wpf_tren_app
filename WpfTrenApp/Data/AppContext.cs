using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WpfTrenApp.Data
{
    internal class AppContext : DbContext
    {
        public DbSet<Atlet> Atlets { get; set; }

        public AppContext() : base("DefaultConnection") { }
    }
}
