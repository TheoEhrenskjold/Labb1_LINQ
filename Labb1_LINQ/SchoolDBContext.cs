using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Labb1_LINQ
{
    public class SchoolDBContext : DbContext
    {
        public DbSet<Lärare> Teacher { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Klass> Class { get; set; }
        public DbSet<Ämne> Course { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-SIK0JHG;Initial Catalog=LINQ_Labb1;Integrated security = True;TrustServerCertificate=True");
        }
    }
}
