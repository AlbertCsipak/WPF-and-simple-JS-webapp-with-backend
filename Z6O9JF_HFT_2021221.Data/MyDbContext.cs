using System;
using Microsoft.EntityFrameworkCore;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Data
{
    public class MyDbContext : DbContext
    {
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Engine> Engine { get; set; }
        public virtual DbSet<Mechanic> Mechanic { get; set; }
        public virtual DbSet<CarService> Service { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public MyDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbBuilder)
        {
            if (!dbBuilder.IsConfigured)
            {
                string connection =@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
                dbBuilder.UseLazyLoadingProxies();
                dbBuilder.UseSqlServer(connection);
            }
        }
    }
}
